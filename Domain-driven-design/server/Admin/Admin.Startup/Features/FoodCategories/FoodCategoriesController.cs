namespace Admin.Startup.Features.FoodCategories
{
    using System.Threading.Tasks;
    using Admin;
    using Microsoft.AspNetCore.Mvc;

    public class FoodCategoriesController : AdministrationController
    {
        private readonly IFoodCategoryService service;

        public FoodCategoriesController(IFoodCategoryService service) => this.service = service;

        [HttpGet]
        [Route("/categories/all")]
        public async Task<IActionResult> GetAllCategories() 
            => this.View("/Features/FoodCategories/Views/AllCategories.cshtml", await this.service.All());

        [HttpGet]
        [Route("{id}/brands")]
        public async Task<IActionResult> GetCategoryBrands(int id) 
            => this.View("/Features/FoodCategories/Views/CategoryBrands.cshtml", await this.service.Brands(id));
    }
}
