namespace PetFoodShop.Admin
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PetFoodShop.Admin.Infrastructure;
    using PetFoodShop.Admin.Services;
    using PetFoodShop.Admin.Services.Foods;
    using PetFoodShop.Admin.Services.Identity;
    using PetFoodShop.Admin.Services.Statistics;
    using PetFoodShop.Infrastructure.Extensions;
    using PetFoodShop.Services;
    using Refit;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                 .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
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
