namespace PetFoodShop.Startup.Extensions
{
    using Hangfire;
    using HealthChecks.UI.Client;
    using Infrastructure;
    using Infrastructure.Persistence.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Web.Middleware;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebService(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            bool withDefaultHealthChecks = true)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseSwaggerUI()
                .UseEndpoints(endpoints =>
                {
                    if (withDefaultHealthChecks)
                    {
                        endpoints.MapHealthChecks();
                    }

                    endpoints.MapControllers();
                })
                .Initialize();

            return app;
        }

        public static IEndpointRouteBuilder MapHealthChecks(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            return endpoints;
        }

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                        InfrastructureConstants.SwaggerConstants.SwaggerEndpoint,
                        InfrastructureConstants.SwaggerConstants.SwaggerName);
                    options.RoutePrefix = string.Empty;
                });

        /* public static IApplicationBuilder Initialize(this IApplicationBuilder app)
         {
             using var serviceScope = app.ApplicationServices.CreateScope();
             var serviceProvider = serviceScope.ServiceProvider;

             var db = serviceProvider.GetRequiredService<DbContext>();

             db.Database.Migrate();

             var seeders = serviceProvider.GetServices<IDataSeeder>();

             foreach (var seeder in seeders)
             {
                 seeder.SeedData();
             }

             return app;
         }*/

        public static IApplicationBuilder Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<IInitializer>();

            foreach (var initializer in initializers)
            {
                initializer.Initialize();
            }

            return app;
        }

        public static IApplicationBuilder UseHangFireDashboard(this IApplicationBuilder app)
        {
            if (app.ApplicationServices.GetService<MessagesHostedService>() != null)
            {
                app.UseHangfireDashboard();
            }

            return app;
        }

        public static IApplicationBuilder UseJwtHeaderAuthentication(this IApplicationBuilder app)
           => app
               .UseMiddleware<JwtHeaderAuthenticationMiddleware>()
               .UseAuthentication();
    }
}
