namespace PetFoodShop.Foods.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Foods.Data;
    using PetFoodShop.Foods.Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly PetFoodDbContext dbContext;
        private readonly IMapper mapper;

        public FoodCategoryService(PetFoodDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AllFoodCategoriesModel>> AllAsync()
            => await this.mapper
                        .ProjectTo<AllFoodCategoriesModel>(this.dbContext.FoodCategories)
                        .ToListAsync();

        public async Task<IEnumerable<FoodCategoryBrand>> CategoryBrandsAsync(int categoryId)
            => await this.mapper
                    .ProjectTo<FoodCategoryBrand>(this.dbContext.FoodBrands.Where(x => x.FoodCategoryId == categoryId))
                    .ToListAsync();
    }
}
