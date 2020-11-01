namespace PetFoodShop.Identity.Startup
{
    using Application.Contracts;
    using Infrastructure;
    using Infrastructure.Persistence;
    using Infrastructure.Persistence.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyTested.AspNetCore.Mvc;
    using PetFoodShop.Application.Contracts;
    using PetFoodShop.Web.Services;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });
            base.ConfigureServices(services);

            ValidateServices(services);

            

            services.ReplaceTransient<UserManager<User>>(_ => IdentityFakes.FakeUserManager);
            services.ReplaceTransient<ITokenGeneratorService>(_ => TokenGeneratorFakes.FakeTokenGenerator);
            services.ReplaceTransient<ICurrentUserService>(_ => CurrentUserServiceFakes.FakeCurrentUserService);
        }

        private static void ValidateServices(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<IMediator>();
            provider.GetRequiredService<IControllerFactory>();
        }
    }
}
