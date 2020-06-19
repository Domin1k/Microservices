namespace PetFoodShop.Foods.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Foods.Services;
    using PetFoodShop.Controllers;
    using System.Threading.Tasks;

    [Route("categories")]
    public class FoodCategoryController : ApiController
    {
        private readonly IFoodCategoryService foodCategoryService;

        public FoodCategoryController(IFoodCategoryService foodCategoryService)
        {
            this.foodCategoryService = foodCategoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var results = await this.foodCategoryService.AllAsync();
            return this.Ok(results);
        }

        [HttpGet]
        [Route("{id}/brands")]
        public async Task<IActionResult> GetCategoryBrands(int id)
        {
            var results = await this.foodCategoryService.CategoryBrandsAsync(id);
            return this.Ok(results);
        }
    }
}
