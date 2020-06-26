namespace PetFoodShop.Cart
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Cart.Data;
    using PetFoodShop.Cart.Services;
    using PetFoodShop.Infrastructure.Extensions;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
             => services
                 .AddWebService<CartDbContext>(this.Configuration)
                 .AddTransient<IRandomizer, Randomizer>()
                 .AddTransient<ICartService, CartService>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
