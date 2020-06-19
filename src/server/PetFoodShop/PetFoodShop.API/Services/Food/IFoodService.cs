namespace PetFoodShop.API.Services
{
    using PetFoodShop.API.Services.Models.Food;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodService
    {
        Task<FoodDetailModel> DetailsAsync(int foodId);

        Task<IEnumerable<FoodModel>> FoodsPerBrand(int brandId);
    }
}
