namespace PetFoodShop.Statistics.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<FoodView> FoodViews { get; set; }

        public DbSet<Statistics> Statistics { get; set; }
    }
}
