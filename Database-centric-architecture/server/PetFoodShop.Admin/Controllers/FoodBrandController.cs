namespace PetFoodShop.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Services.Foods;
    using PetFoodShop.Admin.Services.Models.Foods;
    using System.Threading.Tasks;

    public class FoodBrandController : AdministrationController
    {
        private readonly IFoodService foodBrandService;

        public FoodBrandController(IFoodService foodBrandService)
        {
            this.foodBrandService = foodBrandService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Create(int id) => View(new BrandInputModel { FoodCategoryId = id });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBrand(BrandInputModel model)
            => await this.Handle(
                async () =>
                {
                    await this.foodBrandService.CreateBrand(model);
                },
                success: RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: View(nameof(Create), model));
    }
}
