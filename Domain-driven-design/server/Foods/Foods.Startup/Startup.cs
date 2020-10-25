namespace PetFoodShop.Foods.Startup
{
    using Application;
    using Infrastructure;
    using Infrastructure.Common.Persistence;
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
                .AddWebService(this.Configuration)
                .AddMessaging(this.Configuration)
                .AddCommonDomain()
                .AddFoodsApplication(this.Configuration)
                .AddFoodsInfrastructure(this.Configuration)
                .AddFoodsWebComponents()
                .AddHangFire(this.Configuration);


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseHangFireDashboard();
    }
}
