namespace PetFoodShop.Cart.Infrastructure.Persistence
{
    using System.Reflection;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure.Persistence;

    public class CartDbContext : MessageDbContext, ICartDbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new FoodCategoryConfiguration());

            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }
    }
}
