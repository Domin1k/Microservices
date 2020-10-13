namespace PetFoodShop.Foods.Gateway.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Gateway.Services.Models.Statistics;
    using PetFoodShop.Foods.Gateway.Services.Statistics;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<FoodOutputModel>> TotalViews([FromQuery] IEnumerable<int> ids)
            => await this.statisticsService.GetTotalViews(ids);
    }
}
