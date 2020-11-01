namespace PetFoodShop.Application
{
    using System;
    using System.Reflection;
    using AutoMapper;
    using Behavior;
    using Mapping;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class CommonApplicationConfiguration
    {
        public static IServiceCollection AddCommonApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .Configure<AppSettings>(
                    configuration.GetSection(nameof(AppSettings)),
                    options => options.BindNonPublicProperties = true)
                //.AddEventHandlers()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        //private static IServiceCollection AddEventHandlers(this IServiceCollection services)
        //    => services
        //        .Scan(scan => scan
        //            .FromCallingAssembly()
        //            .AddClasses(classes => classes
        //                .AssignableTo(typeof(IEventHandler<>)))
        //            .AsImplementedInterfaces()
        //            .WithTransientLifetime());
    }
}
