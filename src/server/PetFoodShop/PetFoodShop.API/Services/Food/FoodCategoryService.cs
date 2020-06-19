namespace PetFoodShop.API.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.API.Data;
    using PetFoodShop.API.Services.Models.FoodCategory;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly PetFoodDbContext dbContext;

        public FoodCategoryService(PetFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllFoodCategoriesModel>> AllAsync()
            => await this.dbContext.FoodCategories
                .Select(x => new AllFoodCategoriesModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

        public async Task<IEnumerable<FoodCategoryBrand>> CategoryBrandsAsync(int categoryId)
            => await this.dbContext.FoodBrands
                    .Where(x => x.FoodCategoryId == categoryId)
                    .Select(x => new FoodCategoryBrand
                    {
                        CategoryId = x.FoodCategoryId,
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToListAsync();
    }
}
