namespace PetFoodShop.Domain
{
    using Factories;
    using Microsoft.Extensions.DependencyInjection;

    public static class CommonDomainConfiguration
    {
        public static IServiceCollection AddCommonDomain(this IServiceCollection services)
            => services
                .AddFactories();

        private static IServiceCollection AddFactories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromApplicationDependencies()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
    }
}
