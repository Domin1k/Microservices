namespace PetFoodShop.Foods.Infrastructure.Categories
{
    using Domain.Categories.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure;

    internal interface IFoodCategoryDbContext : IDbContext
    {
        DbSet<FoodBrand> FoodBrands { get;  }

        DbSet<FoodCategory> FoodCategories { get;  }
    }
}
