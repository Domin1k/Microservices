namespace PetFoodShop.Statistics.Application
{
    using System.Reflection;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;

    public static class StatisticsApplicationConfiguration
    {
        public static IServiceCollection AddStatisticsApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddCommonApplication(configuration)
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
