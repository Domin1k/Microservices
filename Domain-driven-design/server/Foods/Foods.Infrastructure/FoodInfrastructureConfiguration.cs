namespace PetFoodShop.Foods.Infrastructure
{
    using System;
    using System.Security.Principal;
    using System.Text;
    using Categories;
    using Common.Persistence;
    using Foods;
    using Hangfire;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using PetFoodShop.Application;
    using PetFoodShop.Application.Contracts;
    using PetFoodShop.Infrastructure;
    using PetFoodShop.Infrastructure.Events;
    using PetFoodShop.Infrastructure.Persistence.Models;

    public static class FoodInfrastructureConfiguration
    {
        public static IServiceCollection AddFoodsInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddScoped<DbContext, FoodDbContext>()
                .AddDbContext<FoodDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString(InfrastructureConstants.ConfigurationConstants.DefaultConnectionString),
                        sqlOpts =>
                        {
                            sqlOpts.MigrationsAssembly(typeof(FoodDbContext).Assembly.FullName);
                            sqlOpts.EnableRetryOnFailure(
                                maxRetryCount: InfrastructureConstants.ConfigurationConstants.DefaultMaxRetryCount,
                                maxRetryDelay: TimeSpan.FromSeconds(InfrastructureConstants.ConfigurationConstants.DefaultMaxTimeoutInSec),
                                errorNumbersToAdd: null);
                        }))
                .EnsureDatabaseCreated<FoodDbContext>()
                .AddScoped<IFoodDbContext>(provider => provider.GetService<FoodDbContext>())
                .AddScoped<IFoodCategoryDbContext>(provider => provider.GetService<FoodDbContext>())
                .AddTransient<IInitializer, FoodsDatabaseInitializer>();

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        
        //private static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services
        //        .AddIdentity<ApplicationUser, IdentityRole>(options =>
        //        {
        //            options.Password.RequiredLength = 6;
        //            options.Password.RequireDigit = false;
        //            options.Password.RequireLowercase = false;
        //            options.Password.RequireNonAlphanumeric = false;
        //            options.Password.RequireUppercase = false;
        //        })
        //        .AddEntityFrameworkStores<FoodDbContext>();

        //    var secret = configuration
        //        .GetSection(nameof(AppSettings))
        //        .GetValue<string>(nameof(AppSettings.Secret));

        //    var key = Encoding.ASCII.GetBytes(secret);

        //    services
        //        .AddAuthentication(authentication =>
        //        {
        //            authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //            authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        })
        //        .AddJwtBearer(bearer =>
        //        {
        //            bearer.RequireHttpsMetadata = false;
        //            bearer.SaveToken = true;
        //            bearer.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuerSigningKey = true,
        //                IssuerSigningKey = new SymmetricSecurityKey(key),
        //                ValidateIssuer = false,
        //                ValidateAudience = false
        //            };
        //        });

        //    services.AddTransient<IIdentity, IdentityService>();
        //    services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();

        //    return services;
        //}
    }
}
