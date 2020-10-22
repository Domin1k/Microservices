namespace PetFoodShop.Foods.Infrastructure.Common.Persistence
{
    using Categories;
    using Domain.Categories.Models;
    using Domain.Foods.Models;
    using Foods;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure.Persistence;
    using System.Reflection;

    // Public because AddWebService TODO to be refactored
    public class FoodDbContext : MessageDbContext, IFoodCategoryDbContext, IFoodDbContext
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
            //builder.ApplyConfiguration(new FoodCategoryConfiguration());

            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }
    }
}
