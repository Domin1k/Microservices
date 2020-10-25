namespace PetFoodShop.Gateway.Startup.Features.Foods
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Refit;
    using Statistics;
    using Web.Controllers.v1;

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

        [HttpGet(Id)]
        [Microsoft.AspNetCore.Authorization.Authorize]
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
