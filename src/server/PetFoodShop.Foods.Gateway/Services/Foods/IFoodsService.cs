namespace PetFoodShop.Foods.Gateway.Services.Foods
{
    using PetFoodShop.Foods.Services.Models;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodsService
    {
        [Get("/api/v1/foods/{id}")]
        Task<FoodDetailModel> DetailsAsync(int id);

        [Get("/api/v1/foods/{brandId}/brands")]
        Task<IEnumerable<FoodOutputModel>> FoodsPerBrand(int brandId);
    }
}
