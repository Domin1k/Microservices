namespace PetFoodShop.Cart.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Cart.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddTransient<IRandomizer, Randomizer>()
                .AddTransient<ICartService, CartService>();
    }
}
