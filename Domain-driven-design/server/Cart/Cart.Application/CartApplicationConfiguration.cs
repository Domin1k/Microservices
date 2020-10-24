namespace PetFoodShop.Cart.Application
{
    using System.Reflection;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;

    public static class CartApplicationConfiguration
    {
        public static IServiceCollection AddCartApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddCommonApplication(configuration)
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
