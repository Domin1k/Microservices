namespace PetFoodShop.Statistics.Domain
{
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Domain;

    public static class StatisticsDomainConfiguration
    {
        public static IServiceCollection AddStatisticsDomain(this IServiceCollection services)
            => services
                .AddCommonDomain()
                .AddInitialData();

        private static IServiceCollection AddInitialData(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IInitialData)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
