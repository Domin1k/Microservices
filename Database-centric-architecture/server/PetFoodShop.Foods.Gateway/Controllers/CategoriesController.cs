namespace PetFoodShop.Foods.Gateway.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Gateway.Services.Foods;
    using System.Threading.Tasks;

    public class CategoriesController : ApiController
    {
        private readonly IFoodCategoriesService foodCategories;

        public CategoriesController(IFoodCategoriesService foodCategories)
        {
            this.foodCategories = foodCategories;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var results = await this.foodCategories.AllAsync();
            return this.Ok(results);
        }

        [HttpGet("{id}/brands")]
        public async Task<IActionResult> GetCategoryBrands(int id)
        {
            var results = await this.foodCategories.CategoryBrandsAsync(id);
            return this.Ok(results);
        }
    }
}
