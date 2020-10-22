namespace PetFoodShop.Identity.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using PetFoodShop.Infrastructure;

    public class AppIdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            optionsBuilder.UseSqlServer(InfrastructureConstants.DataConstants.MigrationConnectionString);

            return new AppIdentityDbContext(optionsBuilder.Options);
        }
    }
}
