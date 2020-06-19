namespace PetFoodShop.Foods.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Foods.Services;
    using PetFoodShop.Controllers;
    using System.Threading.Tasks;

    [Route("foods")]
    public class FoodController : ApiController
    {
        private readonly IFoodService foodService;

        public FoodController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet]
        [Route("{brandId}/brands")]
        public async Task<IActionResult> GetFoodsPerBrand(int brandId)
        {
            var results = await this.foodService.FoodsPerBrand(brandId);
            return this.Ok(results);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var food = await this.foodService.DetailsAsync(id);
            if (food == null)
            {
                return this.NotFound();
            }

            return this.Ok(food);
        }
    }
}
