namespace PetFoodShop.Statistics.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using PetFoodShop.Infrastructure;

    public class StatisticsDbContextFactory : IDesignTimeDbContextFactory<StatisticsDbContext>
    {
        public StatisticsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StatisticsDbContext>();
            optionsBuilder.UseSqlServer(InfrastructureConstants.DataConstants.MigrationConnectionString);

            return new StatisticsDbContext(optionsBuilder.Options);
        }
    }
}
