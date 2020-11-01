namespace PetFoodShop.Cart.Application
{
    using System;
    using System.Reflection;
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;
    using PetFoodShop.Application.Mapping;

    public static class CartApplicationConfiguration
    {
        public static IServiceCollection AddCartApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddCommonApplication(configuration)
                .AddAutoMapper((_, config) => config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly())), Array.Empty<Assembly>())
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
