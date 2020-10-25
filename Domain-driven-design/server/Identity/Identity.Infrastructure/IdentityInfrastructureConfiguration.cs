namespace PetFoodShop.Identity.Infrastructure
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Persistence.Models;
    using PetFoodShop.Infrastructure;

    public static class IdentityInfrastructureConfiguration
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddUserStorage();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddScoped<DbContext, AppIdentityDbContext>()
                .AddDbContext<AppIdentityDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString(InfrastructureConstants.ConfigurationConstants.DefaultConnectionString),
                        sqlOpts =>
                        {
                            sqlOpts.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName);
                            sqlOpts.EnableRetryOnFailure(
                                maxRetryCount: InfrastructureConstants.ConfigurationConstants.DefaultMaxRetryCount,
                                maxRetryDelay: TimeSpan.FromSeconds(InfrastructureConstants.ConfigurationConstants.DefaultMaxTimeoutInSec),
                                errorNumbersToAdd: null);
                        }))
                .EnsureDatabaseCreated<AppIdentityDbContext>()
                .AddTransient<IInitializer, IdentityDatabaseInitializer>();

        private static IServiceCollection AddUserStorage(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            return services;
        }
    }
}
