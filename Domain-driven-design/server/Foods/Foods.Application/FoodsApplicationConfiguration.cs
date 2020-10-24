namespace PetFoodShop.Foods.Application
{
    using System.Reflection;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;

    public static class FoodsApplicationConfiguration
    {
        public static IServiceCollection AddFoodsApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddCommonApplication(configuration)
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
