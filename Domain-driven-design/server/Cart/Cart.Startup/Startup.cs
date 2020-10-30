namespace PetFoodShop.Cart.Startup
{
    using Application;
    using Infrastructure;
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
                .AddWebService(this.Configuration, databaseHealthChecks: true, messagingHealthChecks: true)
                .AddMessaging(this.Configuration)
                .AddCommonDomain()
                .AddCartApplication(this.Configuration)
                .AddCartInfrastructure(this.Configuration)
                .AddCartWebComponents();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env);
    }
}
