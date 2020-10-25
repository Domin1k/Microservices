namespace PetFoodShop.Foods.Infrastructure.Common
{
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Persistence;
    using PetFoodShop.Domain.Factories;
    using PetFoodShop.Infrastructure;

    public class FoodDbContextFactory : IDesignTimeDbContextFactory<FoodDbContext>
    {
        private readonly IBus bus;
        private readonly IMessageFactory messageFactory;

        public FoodDbContextFactory()
        {
        }

        public FoodDbContextFactory(IBus bus, IMessageFactory messageFactory)
        {
            this.bus = bus;
            this.messageFactory = messageFactory;
        }

        public FoodDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FoodDbContext>();
            optionsBuilder.UseSqlServer(InfrastructureConstants.DataConstants.MigrationConnectionString);

            return new FoodDbContext(optionsBuilder.Options, this.bus, this.messageFactory);
        }
    }
}
