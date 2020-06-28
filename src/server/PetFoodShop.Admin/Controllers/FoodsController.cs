namespace PetFoodShop.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Services.Foods;
    using PetFoodShop.Admin.Services.Models.Foods;
    using PetFoodShop.Controllers;
    using System.Threading.Tasks;

    public class FoodsController : AdministrationController
    {
        private readonly IFoodService foodService;

        public FoodsController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet]
        [Route(nameof(Create))]
        public IActionResult Create() => View();

        [HttpGet]
        [Route(nameof(EditPrice))]
        public IActionResult EditPrice() => View();

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(BrandInputModel model)
            => await this.Handle(
                async () =>
                {
                    await this.foodService.CreateBrand(model);
                },
                success: RedirectToAction(nameof(StatisticsController.Index), "Statistics"),
                failure: View(nameof(Create), model));

        [HttpPut]
        [Route(nameof(EditPrice))]
        public async Task<IActionResult> EditPrice(FoodPriceInputModel model)
            => await this.Handle(
                    async () =>
                    {
                        await this.foodService.EditPrice(model);
                    },
                    success: RedirectToAction(nameof(StatisticsController.Index), "Statistics"),
                    failure: View(nameof(EditPrice), model));
    }
}
