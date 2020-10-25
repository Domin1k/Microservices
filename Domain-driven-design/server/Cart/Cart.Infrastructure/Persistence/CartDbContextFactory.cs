namespace PetFoodShop.Cart.Infrastructure.Persistence
{
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using PetFoodShop.Domain.Factories;
    using PetFoodShop.Infrastructure;

    public class CartDbContextFactory : IDesignTimeDbContextFactory<CartDbContext>
    {
        private readonly IBus bus;
        private readonly IMessageFactory messageFactory;

        public CartDbContextFactory()
        {
        }

        public CartDbContextFactory(IBus bus, IMessageFactory messageFactory)
        {
            this.bus = bus;
            this.messageFactory = messageFactory;
        }

        public CartDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CartDbContext>();
            optionsBuilder.UseSqlServer(InfrastructureConstants.DataConstants.MigrationConnectionString);

            return new CartDbContext(optionsBuilder.Options, this.bus, this.messageFactory);
        }
    }
}
