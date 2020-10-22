namespace PetFoodShop.Gateway.Startup.Features.Foods
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Statistics;
    using Web.Controllers.v1;

    public class FoodsController : ApiController
    {
        private const string BrandId = "{brandId}";
        private readonly IFoodsService foodsService;
        private readonly IStatisticsService statisticsService;
        private readonly IMapper mapper;

        public FoodsController(IFoodsService foodsService, IStatisticsService statisticsService, IMapper mapper)
        {
            this.foodsService = foodsService;
            this.statisticsService = statisticsService;
            this.mapper = mapper;
        }

        [HttpGet(BrandId + PathSeparator + nameof(Brands))]
        public async Task<IActionResult> Brands(int brandId)
        {
            var results = await this.foodsService.Brands(brandId);
            return this.Ok(results);
        }

        [HttpGet(Id)]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var food = await this.foodsService.Details(id);
            if (food == null)
            {
                return this.NotFound();
            }

            var totalViews = await this.statisticsService.GetTotalViews(id);

            var model = this.mapper.Map<FoodDetailModelOutputModel, FoodDetailWithTotalViews>(food, opt => opt.AfterMap((src, dest) => dest.TotalViewsCount = totalViews));
            return this.Ok(model);
        }
    }
}
