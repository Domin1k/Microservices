namespace PetFoodShop.Watchdog.Startup
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddHealthChecksUI()
                .AddInMemoryStorage();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseRouting()
                .UseEndpoints(endpoints => endpoints
                    .MapHealthChecksUI(healthChecks => healthChecks
                        .UIPath = "/healthchecks"));
    }
}
