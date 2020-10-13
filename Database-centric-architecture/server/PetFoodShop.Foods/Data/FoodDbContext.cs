namespace PetFoodShop.Foods.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Data;
    using PetFoodShop.Foods.Data.Models;
    using System.Reflection;

    public class FoodDbContext : MessageDbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodBrand> FoodBrands { get; set; }

        public DbSet<FoodCategory> FoodCategories { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();

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

            base.OnModelCreating(builder);
        }
    }
}
