namespace PetFoodShop.Statistics.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Statistics.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
           => services
               .AddTransient<IStatisticsService, StatisticsService>()
               .AddTransient<IFoodViewService, FoodViewService>();
    }
}
