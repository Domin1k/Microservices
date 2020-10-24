namespace PetFoodShop.Cart.Startup
{
    using Application;
    using Application.Contracts;
    using Infrastructure;
    using Infrastructure.Persistence;
    using Infrastructure.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Domain;
    using PetFoodShop.Startup.Extensions;
    using Web;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<CartDbContext>(this.Configuration)
                .AddCommonDomain()
                .AddCartApplication(this.Configuration)
                .AddCartInfrastructure(this.Configuration)
                .AddCartWebComponents()
                .AddTransient<IRandomizer, Randomizer>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env);
    }
}
