namespace PetFoodShop.API.Services
{
    using PetFoodShop.API.Services.Models.FoodCategory;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodCategoryService
    {
        Task<IEnumerable<AllFoodCategoriesModel>> AllAsync();

        Task<IEnumerable<FoodCategoryBrand>> CategoryBrandsAsync(int categoryId);
    }
}
