namespace PetFoodShop.Foods.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Controllers.Models;
    using PetFoodShop.Foods.Services.Food;
    using PetFoodShop.Foods.Services.Models.FoodBrand;
    using System.Threading.Tasks;

    [Route("brands")]
    public class FoodBrandController : ApiController
    {
        private readonly IFoodBrandService brandService;
        private readonly IMapper mapper;

        public FoodBrandController(IFoodBrandService brandService, IMapper mapper)
        {
            this.brandService = brandService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(BrandInputModel model)
        {
            var serviceModel = this.mapper.Map<BrandModel>(model);
            var foodBrandId = await this.brandService.Create(serviceModel);
            return this.Created("/foods/{brandId}/brands", new { id = foodBrandId });
        }
    }
}
