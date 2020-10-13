namespace PetFoodShop.Foods.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Services;
    using System.Threading.Tasks;

    public class CategoriesController : ApiController
    {
        private readonly IFoodCategoryService foodCategoryService;

        public CategoriesController(IFoodCategoryService foodCategoryService)
        {
            this.foodCategoryService = foodCategoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var results = await this.foodCategoryService.AllAsync();
            return this.Ok(results);
        }

        [HttpGet("{id}/brands")]
        public async Task<IActionResult> GetCategoryBrands(int id)
        {
            var results = await this.foodCategoryService.CategoryBrandsAsync(id);
            return this.Ok(results);
        }
    }
}
