namespace PetFoodShop.Admin.Services.Foods
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Services.Models.Foods;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodService
    {
        [Post("/brands/create")]
        Task CreateBrand([FromBody]BrandInputModel model);

        [Put("/foods/editPrice")]
        Task EditPrice([FromBody] FoodPriceInputModel model);

        [Get("/categories/all")]
        Task<IEnumerable<AllFoodCategoriesModel>> AllAsync();

        [Get("/categories/{id}/brands")]
        Task<IEnumerable<FoodCategoryBrand>> CategoryBrandsAsync(int id);

        [Get("/foods/{id}/brands")]
        Task<IEnumerable<FoodOutputModel>> FoodsPerBrand(int id);
    }
}
