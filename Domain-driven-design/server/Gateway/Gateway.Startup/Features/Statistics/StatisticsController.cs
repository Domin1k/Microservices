namespace PetFoodShop.Gateway.Startup.Features.Statistics
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Web.Controllers.v1;

    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService) => this.statisticsService = statisticsService;

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<TotalFoodViewsOutputModel>> TotalViews([FromQuery] IEnumerable<int> ids)
            => await this.statisticsService.GetTotalViews(ids);
    }
}
