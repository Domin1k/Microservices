namespace PetFoodShop.Foods.Gateway.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Gateway.Services.Foods;
    using PetFoodShop.Foods.Gateway.Services.Models.Foods;
    using PetFoodShop.Foods.Gateway.Services.Statistics;
    using PetFoodShop.Foods.Services.Models;
    using System.Threading.Tasks;

    public class FoodsController : ApiController
    {
        private readonly IFoodsService foodsService;
        private readonly IStatisticsService statisticsService;
        private readonly IMapper mapper;

        public FoodsController(IFoodsService foodsService, IStatisticsService statisticsService, IMapper mapper)
        {
            this.foodsService = foodsService;
            this.statisticsService = statisticsService;
            this.mapper = mapper;
        }

        [HttpGet("{brandId}/brands")]
        public async Task<IActionResult> GetFoodsPerBrand(int brandId)
        {
            var results = await this.foodsService.FoodsPerBrand(brandId);
            return this.Ok(results);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var food = await this.foodsService.DetailsAsync(id);
            if (food == null)
            {
                return this.NotFound();
            }

            var totalViews = await this.statisticsService.GetTotalViews(id);

            var model = this.mapper.Map<FoodDetailModel, FoodDetailWithTotalViews>(food, opt => opt.AfterMap((src, dest) => dest.TotalViewsCount = totalViews));
            return this.Ok(model);
        }
    }
}
