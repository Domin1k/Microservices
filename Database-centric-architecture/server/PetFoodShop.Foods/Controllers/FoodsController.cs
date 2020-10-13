namespace PetFoodShop.Foods.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Controllers.Models;
    using PetFoodShop.Foods.Services;
    using PetFoodShop.Infrastructure;
    using System.Threading.Tasks;

    public class FoodsController : ApiController
    {
        private readonly IFoodService foodService;

        public FoodsController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet("{brandId}/brands")]
        public async Task<IActionResult> GetFoodsPerBrand(int brandId)
        {
            var results = await this.foodService.FoodsPerBrand(brandId);
            return this.Ok(results);
        }

        [HttpPut(nameof(EditPrice))]
        [AuthorizeAdministrator]
        public async Task<IActionResult> EditPrice(FoodPriceInputModel model)
        {
            var food = await this.foodService.EditPrice(model.FoodId, model.Price);
            if (food == null)
            {
                return this.NotFound();
            }

            return this.Ok(food);
        }

        [HttpGet("{id}")]
        // Depend on Gateway to authorize the user [Authorize]
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
