namespace PetFoodShop.Identity.Application
{
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;
    using System.Reflection;

    public static class IdentityApplicationConfiguration
    {
        public static IServiceCollection AddIdentityApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddCommonApplication(configuration)
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
