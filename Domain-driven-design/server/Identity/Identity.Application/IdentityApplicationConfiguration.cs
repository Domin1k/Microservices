namespace PetFoodShop.Identity.Application
{
    using System;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;
    using System.Reflection;
    using AutoMapper;
    using PetFoodShop.Application.Mapping;

    public static class IdentityApplicationConfiguration
    {
        public static IServiceCollection AddIdentityApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddCommonApplication(configuration)
                .AddAutoMapper((_, config) => config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly())), Array.Empty<Assembly>())
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
