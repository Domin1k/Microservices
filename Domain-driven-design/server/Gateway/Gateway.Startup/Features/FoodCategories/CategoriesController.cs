namespace PetFoodShop.Gateway.Startup.Features.FoodCategories
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Web.Controllers.v1;

    public class CategoriesController : ApiController
    {
        private readonly IFoodCategoriesService foodCategories;

        public CategoriesController(IFoodCategoriesService foodCategories)
        {
            this.foodCategories = foodCategories;
        }

        [HttpGet(nameof(All))]
        public async Task<IActionResult> All()
        {
            var results = await this.foodCategories.All();
            return this.Ok(results);
        }

        [HttpGet(Id + PathSeparator + nameof(Brands))]
        public async Task<IActionResult> Brands(int id)
        {
            var results = await this.foodCategories.Brands(id);
            return this.Ok(results);
        }
    }
}
