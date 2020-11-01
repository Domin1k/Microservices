namespace PetFoodShop.Foods.Startup
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Startup.Extensions;
    using Statistics.Application;
    using Statistics.Domain;
    using Statistics.Infrastructure;
    using Statistics.Infrastructure.Events;
    using Statistics.Web;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService(this.Configuration, databaseHealthChecks: true, messagingHealthChecks: true)
                .AddMessaging(this.Configuration, new[] { typeof(BrandCreatedConsumer), typeof(FoodViewedConsumer) })
                .AddStatisticsDomain()
                .AddStatisticsApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddWebComponents()
                .AddHangFire(this.Configuration);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseHangFireDashboard();
    }
}
