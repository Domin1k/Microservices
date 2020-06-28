namespace PetFoodShop.Foods.Services.Food
{
    using Microsoft.EntityFrameworkCore.Internal;
    using PetFoodShop.Foods.Data;
    using PetFoodShop.Foods.Data.Models;
    using PetFoodShop.Foods.Infrastructure.Exceptions;
    using PetFoodShop.Foods.Services.Models.FoodBrand;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodBrandService : IFoodBrandService
    {
        private readonly FoodDbContext dbContext;

        public FoodBrandService(FoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Create(BrandModel model)
        {
            if (this.dbContext.FoodBrands.Any(b => b.Name.Equals(model.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new CreateBrandException($"Brand - {model.Name} already exists");
            }

            if (!this.dbContext.FoodCategories.Any(c => c.Id == model.FoodCategoryId))
            {
                throw new FoodCategoryNotFoundException($"Category does not exists");
            }

            var brand = new FoodBrand
            {
                Name = model.Name,
                FoodCategoryId = model.FoodCategoryId
            };
            this.dbContext.FoodBrands.Add(brand);

            await this.dbContext.SaveChangesAsync();
            return brand.Id;
        }
    }
}
