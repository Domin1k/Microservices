namespace PetFoodShop.Admin.Startup
{
    using Application.Contracts;
    using Application.Mapping;
    using AutoMapper;
    using Features;
    using Features.FoodCategories;
    using Features.Foods;
    using Features.Identity;
    using Features.Statistics;
    using global::PetFoodShop.Startup.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Middlewares;
    using Refit;
    using Services;
    using System;
    using System.Reflection;
    using Microsoft.AspNetCore.Authentication.Cookies;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddAutoMapper((_, config) => config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly())), Array.Empty<Assembly>())
                .AddTokenAuthentication(this.Configuration)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtCookieAuthenticationMiddleware>()
                .AddControllersWithViews(options => options
                    .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services
                .AddRefitClient<IIdentityService>()
                .WithConfiguration(serviceEndpoints.Identity);
            services
                .AddRefitClient<IStatisticsService>()
                .WithConfiguration(serviceEndpoints.Statistics);
            services
                .AddRefitClient<IFoodService>()
                .WithConfiguration(serviceEndpoints.Foods);
            services
                .AddRefitClient<IFoodCategoryService>()
                .WithConfiguration(serviceEndpoints.FoodCategories);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage();
            }
            else
            {
                app
                    .UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }

            app
                .UseStaticFiles()
                .UseRouting()
                .UseJwtCookieAuthentication()
                .UseAuthorization()
                .UseEndpoints(e => e.MapDefaultControllerRoute());
        }
    }
}
