namespace PetFoodShop.Gateway.Startup.Features.Foods
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Statistics;
    using System.Net;
    using System.Threading.Tasks;
    using Refit;
    using Web.Controllers.v1;

    [Microsoft.AspNetCore.Authorization.Authorize]
    public class FoodsController : ApiController
    {
        private const string BrandIdPath = "{brandId}";

        private readonly IFoodsService foodsService;
        private readonly IStatisticsService statisticsService;
        private readonly IMapper mapper;

        public FoodsController(IFoodsService foodsService, IStatisticsService statisticsService, IMapper mapper)
        {
            this.foodsService = foodsService;
            this.statisticsService = statisticsService;
            this.mapper = mapper;
        }

        [HttpGet(BrandIdPath + PathSeparator + nameof(Brands))]
        public async Task<IActionResult> Brands(int brandId)
        {
            var result = await this.foodsService.Brands(brandId);
            return this.Ok(result);
        }

        [HttpGet(Id)]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var food = await this.foodsService.Details(id);

                var totalViews = await this.statisticsService.GetTotalViews(id);

                var model = this.mapper.Map<FoodDetailModelOutputModel, FoodDetailWithTotalViews>(
                    food,
                    opt => opt.AfterMap((src, dest) => dest.TotalViewsCount = totalViews));
                return this.Ok(model);
            }
            catch (ValidationApiException e)
            {
                switch (e.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return this.NotFound();
                    case HttpStatusCode.BadRequest:
                        return this.BadRequest();
                    default:
                        throw;
                }
            }
        }
    }
}
