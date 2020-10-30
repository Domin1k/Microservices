namespace PetFoodShop.Identity.Startup
{
    using Application;
    using Application.Contracts;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Startup.Extensions;
    using Web;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService(this.Configuration, databaseHealthChecks: true, messagingHealthChecks: false)
                .AddIdentityApplication(this.Configuration)
                .AddIdentityInfrastructure(this.Configuration)
                .AddWebComponents()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
                .AddTransient<IIdentityService, IdentityService>();
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseHangFireDashboard();
    }
}
