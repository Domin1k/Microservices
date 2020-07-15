namespace PetFoodShop.Infrastructure.Extensions
{
    using Hangfire;
    using HealthChecks.UI.Client;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PetFoodShop.Messages;
    using PetFoodShop.Services;
    using static InfrastructureConstants.SwaggerConstants;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebService(this IApplicationBuilder app, IWebHostEnvironment env)
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
                .UseHangFire()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapHealthChecks("/health", new HealthCheckOptions
                    {
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                    });

                    endpoints.MapControllers();
                });

            return app;
        }

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(SwaggerEndpoint, SwaggerName);
                    options.RoutePrefix = string.Empty;
                });

        public static IApplicationBuilder Initialize(this IApplicationBuilder app)
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
        }

        public static IApplicationBuilder UseHangFire(this IApplicationBuilder app)
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
