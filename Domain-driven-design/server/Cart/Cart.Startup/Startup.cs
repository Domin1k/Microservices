namespace Cart.Startup
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;
    using PetFoodShop.Cart.Application.Contracts;
    using PetFoodShop.Cart.Infrastructure;
    using PetFoodShop.Cart.Infrastructure.Persistence;
    using PetFoodShop.Cart.Infrastructure.Services;
    using PetFoodShop.Cart.Web;
    using PetFoodShop.Domain;
    using PetFoodShop.Startup.Extensions;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<CartDbContext>(this.Configuration)
                .AddCommonDomain()
                .AddCommonApplication(this.Configuration)
                .AddCartInfrastructure(this.Configuration)
                .AddCartWebComponents()
                .AddTransient<IRandomizer, Randomizer>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env);
    }
}
