namespace PetFoodShop.Admin.Services.Foods
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Services.Models.Foods;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodService
    {
        [Post("/api/v1/brands/create")]
        Task CreateBrand([FromBody]BrandInputModel model);

        [Put("/api/v1/foods/editPrice")]
        Task EditPrice([FromBody] FoodPriceInputModel model);

        [Get("/api/v1/categories/all")]
        Task<IEnumerable<AllFoodCategoriesModel>> AllAsync();

        [Get("/api/v1/categories/{id}/brands")]
        Task<IEnumerable<FoodCategoryBrand>> CategoryBrandsAsync(int id);

        [Get("/api/v1/foods/{id}/brands")]
        Task<IEnumerable<FoodOutputModel>> FoodsPerBrand(int id);
    }
}
