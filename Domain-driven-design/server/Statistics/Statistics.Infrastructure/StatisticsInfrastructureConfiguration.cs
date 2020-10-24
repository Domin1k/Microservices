namespace PetFoodShop.Statistics.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using PetFoodShop.Application.Contracts;
    using PetFoodShop.Infrastructure;

    public static class StatisticsInfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<StatisticsDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString(InfrastructureConstants.ConfigurationConstants.DefaultConnectionString),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(StatisticsDbContext).Assembly.FullName)))
                .EnsureDatabaseCreated<StatisticsDbContext>()
                .AddScoped<IStatisticsDbContext>(provider => provider.GetService<StatisticsDbContext>())
                .AddTransient<IInitializer, StatisticsDatabaseInitializer>();


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
