namespace PetFoodShop.Statistics
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Infrastructure.Extensions;
    using PetFoodShop.Services;
    using PetFoodShop.Statistics.Data;
    using PetFoodShop.Statistics.Messages;
    using PetFoodShop.Statistics.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<StatisticsDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, StatisticsDataSeeder>()
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddTransient<IFoodViewService, FoodViewService>()
                .AddMessaging(this.Configuration, new[] { typeof(BrandCreatedConsumer), typeof(FoodViewedConsumer) });

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
