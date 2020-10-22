namespace PetFoodShop.Statistics.Infrastructure.Persistence
{
    using System.Reflection;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class StatisticsDbContext : DbContext, IStatisticsDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
          : base(options)
        {
        }

        public DbSet<Statistics> Statistics { get; set; }

        public DbSet<FoodView> FoodViews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
