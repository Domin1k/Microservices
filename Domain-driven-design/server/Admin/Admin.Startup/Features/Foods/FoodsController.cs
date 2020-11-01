namespace PetFoodShop.Admin.Startup.Features.Foods
{
    using System.Threading.Tasks;
    using Admin;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class FoodsController : AdministrationController
    {
        private readonly IFoodService foodService;

        public FoodsController(IFoodService foodService) => this.foodService = foodService;

        [HttpGet]
        [Route("/foods/{brandId}/brands")]
        public async Task<IActionResult> GetFoodsPerBrand(int brandId) 
            => this.View(await this.foodService.Brands(brandId));

        [HttpGet]
        [Route(nameof(EditPrice))]
        public IActionResult EditPrice(int foodId, decimal price) 
            => this.View(new EditPriceCommand(foodId, price));

        [HttpPost]
        [Route(nameof(EditPrice))]
        public async Task<IActionResult> EditPrice(EditPriceCommand command)
            => await this.Handle(
                    async () =>
                    {
                        await this.foodService.EditPrice(command);
                    },
                    success: this.RedirectToAction(nameof(HomeController.Index), "Home"),
                    failure: this.View(command));
    }
}
