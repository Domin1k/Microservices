namespace PetFoodShop.Identity
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Identity.Data;
    using PetFoodShop.Identity.Infrastructure.Extensions;
    using PetFoodShop.Identity.Services;
    using PetFoodShop.Identity.Services.Identity;
    using PetFoodShop.Infrastructure.Extensions;
    using PetFoodShop.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<AppIdentityDbContext>(this.Configuration)
                .AddUserStorage()
                .AddTransient<IDataSeeder, IdentityDataSeeder>()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
                .AddTransient<IIdentityService, IdentityService>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
