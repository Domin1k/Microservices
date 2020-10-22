namespace Admin.Startup.Features.FoodCategories
{
    using System.Threading.Tasks;
    using Admin;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class FoodBrandController : AdministrationController
    {
        private readonly IFoodCategoryService foodBrandService;

        public FoodBrandController(IFoodCategoryService foodBrandService) => this.foodBrandService = foodBrandService;

        [HttpGet]
        [Route("{id}")]
        public IActionResult Create(int id) 
            => this.View("/Features/FoodCategories/Views/CreateBrand.cshtml", new CreateBrandCommand { FoodCategoryId = id });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand model)
            => await this.Handle(
                async () =>
                {
                    await this.foodBrandService.CreateBrand(model);
                },
                success: this.RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: this.View("/Features/FoodCategories/Views/CreateBrand.cshtml", model));
    }
}
