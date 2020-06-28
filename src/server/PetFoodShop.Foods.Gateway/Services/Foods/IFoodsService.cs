namespace PetFoodShop.Foods.Gateway.Services.Foods
{
    using PetFoodShop.Foods.Gateway.Services.Models.FoodCategories;
    using PetFoodShop.Foods.Services.Models;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodsService
    {
        [Get("/foods/{id}")]
        Task<FoodDetailModel> DetailsAsync(int id);

        [Get("/foods/{brandId}/brands")]
        Task<IEnumerable<FoodOutputModel>> FoodsPerBrand(int brandId);

        [Get("/categories/all")]
        Task<IEnumerable<AllFoodCategoriesModel>> AllAsync();

        [Get("/categories/{id}/brands")]
        Task<IEnumerable<FoodCategoryBrand>> CategoryBrandsAsync(int id);
    }
}
