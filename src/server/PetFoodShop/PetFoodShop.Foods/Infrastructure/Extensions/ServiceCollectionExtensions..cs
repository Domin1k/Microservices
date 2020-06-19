namespace PetFoodShop.Foods.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Foods.Services;
    using PetFoodShop.Foods.Services.Cart;
    using PetFoodShop.Foods.Services.Common;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddTransient<IFoodService, FoodService>()
                .AddTransient<IRandomizer, Randomizer>()
                .AddTransient<ICartService, CartService>()
                .AddTransient<IFoodCategoryService, FoodCategoryService>();
    }
}
