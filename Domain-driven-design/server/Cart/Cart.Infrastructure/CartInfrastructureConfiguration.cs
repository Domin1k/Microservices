namespace PetFoodShop.Cart.Infrastructure
{
    using System;
    using Application.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using PetFoodShop.Application.Contracts;
    using PetFoodShop.Infrastructure;
    using Services;

    public static class CartInfrastructureConfiguration
    {
        public static IServiceCollection AddCartInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories()
                .AddTransient<IRandomizer, Randomizer>();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddScoped<DbContext, CartDbContext>()
                .AddDbContext<CartDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString(InfrastructureConstants.ConfigurationConstants.DefaultConnectionString),
                        sqlOpts =>
                        {
                            sqlOpts.MigrationsAssembly(typeof(CartDbContext).Assembly.FullName);
                            sqlOpts.EnableRetryOnFailure(
                                maxRetryCount: InfrastructureConstants.ConfigurationConstants.DefaultMaxRetryCount,
                                maxRetryDelay: TimeSpan.FromSeconds(InfrastructureConstants.ConfigurationConstants.DefaultMaxTimeoutInSec),
                                errorNumbersToAdd: null);
                        }))
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
