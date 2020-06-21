namespace PetFoodShop.Cart.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Cart.Data.Models;

    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shippment> Shippments { get; set; }
    }
}
