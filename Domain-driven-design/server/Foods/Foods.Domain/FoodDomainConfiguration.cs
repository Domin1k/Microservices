namespace PetFoodShop.Foods.Domain
{
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Domain;

    public static class FoodDomainConfiguration
    {
        public static IServiceCollection AddFoodsDomain(this IServiceCollection services)
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
