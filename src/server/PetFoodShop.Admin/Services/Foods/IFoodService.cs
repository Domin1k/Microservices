namespace PetFoodShop.Admin.Services.Foods
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Services.Models.Foods;
    using Refit;
    using System.Threading.Tasks;

    public interface IFoodService
    {
        [Post("/brands/create")]
        Task CreateBrand([FromBody]BrandInputModel model);

        [Put("/foods/editPrice")]
        Task EditPrice([FromBody] FoodPriceInputModel model);
    }
}
