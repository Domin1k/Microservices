namespace PetFoodShop.Foods
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Foods.Data;
    using PetFoodShop.Foods.Infrastructure.Extensions;
    using PetFoodShop.Foods.Services;
    using PetFoodShop.Foods.Services;
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
                .AddWebService<FoodDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, FoodDataSeeder>()
                .AddTransient<IFoodBrandService, FoodBrandService>()
                .AddTransient<IFoodService, FoodService>()
                .AddTransient<IFoodCategoryService, FoodCategoryService>()
                .AddHangFire(this.Configuration)
                .AddMessaging(this.Configuration);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseHangFireDashboard()
                .Initialize();
    }
}
