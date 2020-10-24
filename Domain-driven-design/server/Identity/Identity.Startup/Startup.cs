namespace PetFoodShop.Identity.Startup
{
    using Application;
    using Application.Contracts;
    using Infrastructure;
    using Infrastructure.Persistence;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;
    using PetFoodShop.Startup.Extensions;
    using Web;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<AppIdentityDbContext>(this.Configuration)
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
