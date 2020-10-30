namespace PetFoodShop.Startup.Extensions
{
    using Application;
    using Application.Contracts;
    using GreenPipes;
    using Hangfire;
    using Infrastructure.Persistence.Models;
    using MassTransit;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using System;
    using System.Reflection;
    using System.Text;
    using Infrastructure;
    using Web.Services;
    using static Infrastructure.InfrastructureConstants.ConfigurationConstants;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebService(
            this IServiceCollection services,
            IConfiguration configuration,
            bool databaseHealthChecks = true,
            bool messagingHealthChecks = true)
        {
            services
                .AddApplicationSettings(configuration)
                .AddTokenAuthentication(configuration)
                .AddSwagger()
                .AddHealthCheck(configuration, databaseHealthChecks, messagingHealthChecks)
                .AddControllers();

            return services;
        }

        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
            => services
                .Configure<AppSettings>(configuration
                    .GetSection(nameof(AppSettings)));

        public static IServiceCollection AddTokenAuthentication(
            this IServiceCollection services,
            IConfiguration configuration,
            JwtBearerEvents events = null)
        {
            var secret = configuration
                .GetSection(nameof(AppSettings))
                .GetValue<string>(nameof(AppSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    if (events != null)
                    {
                        bearer.Events = events;
                    }
                });

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration, params Type[] consumers)
        {
            var messagingSettings = GetMessageQueueSettings(configuration);
            services
                .AddMassTransit(mt =>
                {
                    consumers.ForEach(consumer => mt.AddConsumer(consumer));

                    mt.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        rmq.Host(messagingSettings.Host, host =>
                        {
                            host.Username(messagingSettings.UserName);
                            host.Password(messagingSettings.Password);
                        });

                        rmq.UseHealthCheck(bus);
                        consumers.ForEach(consumer => 
                            rmq.ReceiveEndpoint(consumer.FullName, endpoint =>
                            {
                                endpoint.PrefetchCount = 4;
                                endpoint.UseMessageRetry(x => x.Interval(5, 100));
                                endpoint.ConfigureConsumer(bus, consumer);
                            }));
                    }));
                })
                .AddMassTransitHostedService();

            return services;
        }

        public static IServiceCollection AddHangFire(this IServiceCollection services, IConfiguration configuration)
            => services
               .AddHangfire(config => config
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UseSqlServerStorage(configuration.GetConnectionString(DefaultConnectionString)))
               .AddHangfireServer()
               .AddHostedService<MessagesHostedService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
           => services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc(
                   "v1",
                   new OpenApiInfo
                   {
                       Title = Assembly.GetExecutingAssembly().GetName().Name,
                       Version = "v1"
                   });
           });

        public static IServiceCollection AddHealthCheck(
            this IServiceCollection services,
            IConfiguration configuration,
            bool databaseHealthChecks = true,
            bool messagingHealthChecks = true)
        {
            var healthChecks = services.AddHealthChecks();

            if (databaseHealthChecks)
            {
                healthChecks
                    .AddSqlServer(configuration.GetConnectionString(DefaultConnectionString));
            }

            if (messagingHealthChecks)
            {
                var messageQueueSettings = GetMessageQueueSettings(configuration);

                var messageQueueConnectionString =
                    $"amqp://{messageQueueSettings.UserName}:{messageQueueSettings.Password}@{messageQueueSettings.Host}/";

                healthChecks
                    .AddRabbitMQ(rabbitConnectionString: messageQueueConnectionString);
            }

            return services;
        }

        private static MessageQueueSettings GetMessageQueueSettings(IConfiguration configuration)
        {
            var settings = configuration.GetSection(nameof(MessageQueueSettings));

            return new MessageQueueSettings(
                settings.GetValue<string>(nameof(MessageQueueSettings.Host)),
                settings.GetValue<string>(nameof(MessageQueueSettings.UserName)),
                settings.GetValue<string>(nameof(MessageQueueSettings.Password)));
        }
    }
}
