namespace PetFoodShop.Identity.Infrastructure
{
    using Microsoft.AspNetCore.Identity;
    using Persistence.Models;
    using PetFoodShop.Infrastructure;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Web;

    public class IdentityDatabaseInitializer : IInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDatabaseInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Initialize() => this.InitializeAsync().Wait();

        private async Task InitializeAsync()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            var adminRole = new IdentityRole(WebConstants.AuthConstants.AdministratorRoleName);

            await this.roleManager.CreateAsync(adminRole);

            var adminUser = new User
            {
                UserName = "admin@mysite.com",
                Email = "admin@mysite.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            await this.userManager.CreateAsync(adminUser, "123456");

            await this.userManager.AddToRoleAsync(adminUser, WebConstants.AuthConstants.AdministratorRoleName);
        }
    }
}
