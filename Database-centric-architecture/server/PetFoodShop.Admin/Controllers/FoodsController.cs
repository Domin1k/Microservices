namespace PetFoodShop.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Services.Foods;
    using PetFoodShop.Admin.Services.Models.Foods;
    using System.Threading.Tasks;

    public class FoodsController : AdministrationController
    {
        private readonly IFoodService foodService;

        public FoodsController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet]
        [Route("/foods/{brandId}/brands")]
        public async Task<IActionResult> GetFoodsPerBrand(int brandId) => View(await this.foodService.FoodsPerBrand(brandId));

        [HttpGet]
        [Route(nameof(EditPrice))]
        public IActionResult EditPrice(int foodId, decimal price) => View(new FoodPriceInputModel(foodId, price));

        [HttpGet]
        [Route("/categories/all")]
        public async Task<IActionResult> GetAllCategories() => View(await this.foodService.AllAsync());

        [HttpGet]
        [Route("{id}/brands")]
        public async Task<IActionResult> GetCategoryBrands(int id) => View(await this.foodService.CategoryBrandsAsync(id));

        [HttpPost]
        [Route(nameof(EditPrice))]
        public async Task<IActionResult> EditPrice(FoodPriceInputModel model)
            => await this.Handle(
                    async () =>
                    {
                        await this.foodService.EditPrice(model);
                    },
                    success: RedirectToAction(nameof(HomeController.Index), "Home"),
                    failure: View(nameof(EditPrice), model));
    }
}
