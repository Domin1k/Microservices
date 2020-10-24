namespace PetFoodShop.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class CommonInfrastructureConfiguration
    {
        public static IServiceCollection EnsureDatabaseCreated<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext
        {
            var provider = services.BuildServiceProvider();
            var db = provider.GetService<TDbContext>();
            db.Database.EnsureCreated();
            return services;
        }
    }
}
