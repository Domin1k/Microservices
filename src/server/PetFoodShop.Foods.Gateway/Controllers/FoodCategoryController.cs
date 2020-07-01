namespace PetFoodShop.Foods.Gateway.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Gateway.Services.Foods;
    using System.Threading.Tasks;

    public class FoodCategoryController : ApiController
    {
        private readonly IFoodCategoriesService foodCategories;

        public FoodCategoryController(IFoodCategoriesService foodCategories)
        {
            this.foodCategories = foodCategories;
        }

        [HttpGet]
        [Route("/categories/all")]
        public async Task<IActionResult> GetAll()
        {
            var results = await this.foodCategories.AllAsync();
            return this.Ok(results);
        }

        [HttpGet]
        [Route("/categories/{id}/brands")]
        public async Task<IActionResult> GetCategoryBrands(int id)
        {
            var results = await this.foodCategories.CategoryBrandsAsync(id);
            return this.Ok(results);
        }
    }
}
