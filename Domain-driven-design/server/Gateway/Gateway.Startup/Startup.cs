namespace PetFoodShop.Gateway.Startup
{
    using System;
    using System.Reflection;
    using Application.Contracts;
    using Application.Mapping;
    using AutoMapper;
    using Features;
    using Features.FoodCategories;
    using Features.Foods;
    using Features.Statistics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Startup.Extensions;
    using Refit;
    using Services;
    using Web.Middleware;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddTransient<JwtHeaderAuthenticationMiddleware>()
                .AddAutoMapper((_, config) => config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly())), Array.Empty<Assembly>())
                .AddTokenAuthentication(this.Configuration)
                .AddSwagger()
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddControllers();

            services
                .AddRefitClient<IStatisticsService>()
                .WithConfiguration(serviceEndpoints.Statistics);

            services
                .AddRefitClient<IFoodsService>()
                .WithConfiguration(serviceEndpoints.Foods);

            services
                .AddRefitClient<IFoodCategoriesService>()
                .WithConfiguration(serviceEndpoints.FoodCategories);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var allowedOrigins = this.Configuration
                .GetSection(nameof(GatewaySettings))
                .GetValue<string>(nameof(GatewaySettings.AllowedOrigins));

            app
                .UseJwtHeaderAuthentication()
                .UseRouting()
                .UseCors(options => options
                    .WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials())
                .UseAuthentication()
                .UseAuthorization()
                .UseSwaggerUI()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .Initialize();
        }
    }
}