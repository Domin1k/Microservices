namespace PetFoodShop.Statistics.Infrastructure.Persistence
{
    using System.Reflection;
    using Domain.Models;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Domain.Factories;
    using PetFoodShop.Infrastructure.Persistence;

    public class StatisticsDbContext : MessageDbContext, IStatisticsDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options, IBus bus, IMessageFactory messageFactory)
          : base(options, bus, messageFactory)
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
