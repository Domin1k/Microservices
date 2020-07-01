namespace PetFoodShop.Foods.Gateway.Services.Foods
{
    using PetFoodShop.Foods.Gateway.Services.Models.FoodCategories;
    using Refit;
    using System.Collections.Generic;

    using System.Threading.Tasks;

    public interface IFoodCategoriesService
    {
        [Get("/categories/all")]
        Task<IEnumerable<AllFoodCategoriesModel>> AllAsync();

        [Get("/categories/{id}/brands")]
        Task<IEnumerable<FoodCategoryBrand>> CategoryBrandsAsync(int id);
    }
}
