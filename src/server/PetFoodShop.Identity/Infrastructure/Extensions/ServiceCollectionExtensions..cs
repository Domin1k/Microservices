namespace PetFoodShop.Identity.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Identity.Data;
    using PetFoodShop.Identity.Data.Models;
    using PetFoodShop.Identity.Services;
    using PetFoodShop.Identity.Services.Identity;
    using PetFoodShop.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserStorage(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
           => services
               .AddTransient<IDataSeeder, IdentityDataSeeder>()
               .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
               .AddTransient<IIdentityService, IdentityService>();
    }
}
