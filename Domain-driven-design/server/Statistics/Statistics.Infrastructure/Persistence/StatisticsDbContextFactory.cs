namespace PetFoodShop.Statistics.Infrastructure.Persistence
{
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using PetFoodShop.Domain.Factories;
    using PetFoodShop.Infrastructure;

    public class StatisticsDbContextFactory : IDesignTimeDbContextFactory<StatisticsDbContext>
    {
        private readonly IBus bus;
        private readonly IMessageFactory messageFactory;

        public StatisticsDbContextFactory()
        {
        }

        public StatisticsDbContextFactory(IBus bus, IMessageFactory messageFactory)
        {
            this.bus = bus;
            this.messageFactory = messageFactory;
        }

        public StatisticsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StatisticsDbContext>();
            optionsBuilder.UseSqlServer(InfrastructureConstants.DataConstants.MigrationConnectionString);

            return new StatisticsDbContext(optionsBuilder.Options, this.bus, this.messageFactory);
        }
    }
}
