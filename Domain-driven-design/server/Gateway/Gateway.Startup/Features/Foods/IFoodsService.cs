namespace PetFoodShop.Gateway.Startup.Features.Foods
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Refit;

    public interface IFoodsService
    {
        [Get("/api/v1/foods/{id}")]
        Task<FoodDetailModelOutputModel> Details(int id);

        [Get("/api/v1/foods/{brandId}/brands")]
        Task<IEnumerable<BrandFoodOutputModel>> Brands(int brandId);
    }
}
