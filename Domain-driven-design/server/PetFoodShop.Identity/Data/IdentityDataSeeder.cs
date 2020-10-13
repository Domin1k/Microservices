namespace PetFoodShop.Identity.Data
{
    using Microsoft.AspNetCore.Identity;
    using PetFoodShop.Identity.Data.Models;
    using PetFoodShop.Infrastructure;
    using PetFoodShop.Services;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static PetFoodShop.Infrastructure.InfrastructureConstants.AuthConstants;

    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDataSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            Task
                .Run(async () =>
                {
                    var adminRole = new IdentityRole(AdministratorRoleName);

                    await this.roleManager.CreateAsync(adminRole);

                    var adminUser = new User
                    {
                        UserName = "admin@mysite.com",
                        Email = "admin@mysite.com",
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    await userManager.CreateAsync(adminUser, "123456");

                    await userManager.AddToRoleAsync(adminUser, AdministratorRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
