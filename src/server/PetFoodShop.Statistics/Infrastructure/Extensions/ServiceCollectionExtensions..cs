namespace PetFoodShop.Statistics.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Services;
    using PetFoodShop.Statistics.Data;
    using PetFoodShop.Statistics.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
           => services
               .AddTransient<IDataSeeder, StatisticsDataSeeder>()
               .AddTransient<IStatisticsService, StatisticsService>()
               .AddTransient<IFoodViewService, FoodViewService>();
    }
}
