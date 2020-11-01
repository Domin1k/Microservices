namespace PetFoodShop.Notifications
{
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PetFoodShop.Notifications.Hub;
    using PetFoodShop.Notifications.Messages;
    using PetFoodShop.Startup.Extensions;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddCors()
                .AddTokenAuthentication(this.Configuration, JwtConfiguration.BearerEvents)
                .AddHealthCheck(this.Configuration, databaseHealthChecks: false)
                .AddMessaging(this.Configuration, new[] { typeof(PriceEditedConsumer), typeof(BrandCreatedConsumer) })
                .AddSignalR();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var allowedOrigins = this.Configuration
                .GetSection(nameof(NotificationSettings))
                .GetValue<string>(nameof(NotificationSettings.AllowedOrigins));

            app
                .UseRouting()
                .UseCors(options => options
                    .WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapHealthChecks()
                    .MapHub<NotificationsHub>("/notifications"));
        }
    }
}
