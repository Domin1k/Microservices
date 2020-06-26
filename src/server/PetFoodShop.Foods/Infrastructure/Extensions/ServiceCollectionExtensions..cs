namespace PetFoodShop.Foods.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Foods.Services;
    using PetFoodShop.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddTransient<IDataSeeder, FoodDataSeeder>()
                .AddTransient<IFoodService, FoodService>()
                .AddTransient<IFoodCategoryService, FoodCategoryService>();
    }
}
