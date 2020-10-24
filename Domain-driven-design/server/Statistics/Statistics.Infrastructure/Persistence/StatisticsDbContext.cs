namespace PetFoodShop.Statistics.Infrastructure.Persistence
{
    using System.Reflection;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure.Persistence;

    public class StatisticsDbContext : MessageDbContext, IStatisticsDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
          : base(options)
        {
        }

        public DbSet<Statistics> Statistics { get; set; }

        public DbSet<FoodView> FoodViews { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new FoodCategoryConfiguration());

            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }
    }
}
