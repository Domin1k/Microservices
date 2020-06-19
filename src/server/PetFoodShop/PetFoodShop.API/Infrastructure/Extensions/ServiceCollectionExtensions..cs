namespace PetFoodShop.API.Infrastructure.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using PetFoodShop.API.Data;
    using PetFoodShop.API.Services;
    using PetFoodShop.API.Services.Cart;
    using PetFoodShop.API.Services.Common;

    public static class ServiceCollectionExtensions
    {
        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppSettings>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<PetFoodDbContext>(options => options
                    .UseSqlServer(configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddSwagger(this IServiceCollection services)
           => services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc(
                   "v1",
                   new OpenApiInfo
                   {
                       Title = "PetFoodShop API",
                       Version = "v1"
                   });
           });

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddTransient<IFoodService, FoodService>()
                .AddTransient<IRandomizer, Randomizer>()
                .AddTransient<ICartService, CartService>()
                .AddTransient<IFoodCategoryService, FoodCategoryService>();
    }
}
