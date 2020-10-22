namespace PetFoodShop.Foods.Web
{
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Application;
    using PetFoodShop.Application.Contracts;
    using PetFoodShop.Web.Services;

    public static class FoodsWebConfiguration
    {
        public static IServiceCollection AddFoodsWebComponents(this IServiceCollection services)
        {
            services
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddControllers()
                .AddFluentValidation(validation => validation.RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
