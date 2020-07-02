namespace PetFoodShop.Foods.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Controllers.Models;
    using PetFoodShop.Foods.Services;
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

        [HttpPut]
        [Authorize]
        [Route(nameof(EditPrice))]
        public async Task<IActionResult> EditPrice(FoodPriceInputModel model)
        {
            var food = await this.foodService.EditPrice(model.FoodId, model.Price);
            if (food == null)
            {
                return this.NotFound();
            }

            return this.Ok(food);
        }

        [HttpGet]
        // Depend on Gateway to authorize the user [Authorize]
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
