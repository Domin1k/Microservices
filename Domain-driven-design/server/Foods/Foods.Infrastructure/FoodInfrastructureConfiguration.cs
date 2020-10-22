namespace PetFoodShop.Foods.Infrastructure
{
    using System.Security.Principal;
    using System.Text;
    using Categories;
    using Common.Persistence;
    using Foods;
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

    public static class FoodInfrastructureConfiguration
    {
        public static IServiceCollection AddFoodsInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories();
              // .AddIdentity(configuration)
              // .AddTransient<IEventDispatcher, EventDispatcher>();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<FoodDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(FoodDbContext).Assembly.FullName)))
                .AddScoped<IFoodDbContext>(provider => provider.GetService<FoodDbContext>())
                .AddScoped<IFoodCategoryDbContext>(provider => provider.GetService<FoodDbContext>());
               // .AddTransient<IInitializer, DatabaseInitializer>();

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
