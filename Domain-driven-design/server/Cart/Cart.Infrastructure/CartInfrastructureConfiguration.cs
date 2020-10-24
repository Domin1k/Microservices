namespace PetFoodShop.Cart.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using PetFoodShop.Application.Contracts;
    using PetFoodShop.Infrastructure;

    public static class CartInfrastructureConfiguration
    {
        public static IServiceCollection AddCartInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<CartDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString(InfrastructureConstants.ConfigurationConstants.DefaultConnectionString),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(CartDbContext).Assembly.FullName)))
                .EnsureDatabaseCreated<CartDbContext>()
                .AddScoped<ICartDbContext>(provider => provider.GetService<CartDbContext>())
                .AddTransient<IInitializer, CartDatabaseInitializer>();

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());


    }
}
