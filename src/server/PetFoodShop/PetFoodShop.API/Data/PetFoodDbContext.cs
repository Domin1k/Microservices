namespace PetFoodShop.API.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.API.Data.Models;

    public class PetFoodDbContext : DbContext
    {
        public PetFoodDbContext(DbContextOptions<PetFoodDbContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodBrand> FoodBrands { get; set; }

        public DbSet<FoodCategory> FoodCategories { get; set; }

        public DbSet<Shippment> Shippments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FoodCategory>()
                .HasMany(x => x.FoodBrands)
                .WithOne(x => x.FoodCategory)
                .HasForeignKey(x => x.FoodCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FoodBrand>()
                .HasMany(x => x.Foods)
                .WithOne(x => x.FoodBrand)
                .HasForeignKey(x => x.FoodBrandId)
                .OnDelete(DeleteBehavior.Restrict);

            /*builder.Entity<User>()
               .HasMany(x => x.Shippments)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);*/

            base.OnModelCreating(builder);
        }
    }
}
