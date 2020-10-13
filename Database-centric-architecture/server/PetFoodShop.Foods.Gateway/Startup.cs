namespace PetFoodShop.Foods.Gateway
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Foods.Gateway.Services;
    using PetFoodShop.Foods.Gateway.Services.Foods;
    using PetFoodShop.Foods.Gateway.Services.Statistics;
    using PetFoodShop.Infrastructure;
    using PetFoodShop.Infrastructure.Extensions;
    using PetFoodShop.Services;
    using Refit;
    using System.Reflection;

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
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddTokenAuthentication(this.Configuration)
                .AddSwagger()
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtHeaderAuthenticationMiddleware>()
                .AddControllers();

            services
                .AddRefitClient<IStatisticsService>()
                .WithConfiguration(serviceEndpoints.Statistics);

            services
                .AddRefitClient<IFoodsService>()
                .WithConfiguration(serviceEndpoints.Foods);

            services
                .AddRefitClient<IFoodCategoriesService>()
                .WithConfiguration(serviceEndpoints.Foods);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env, false)
                .UseJwtHeaderAuthentication();
    }
}
