namespace PetFoodShop.Gateway.Startup.Features.Foods
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Refit;

    public interface IFoodsService
    {
        [Get("/api/v1/foods/{foodId}")]
        Task<FoodDetailModelOutputModel> Details([FromRoute]int foodId);
    }
}
