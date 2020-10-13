namespace PetFoodShop.Statistics.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Statistics.Services;
    using PetFoodShop.Statistics.Services.Models;
    using System.Threading.Tasks;

    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
        {
            this.statistics = statistics;
        }

        [HttpGet]
        public async Task<StatisticsOutputModel> Full()
            => await this.statistics.Full();
    }
}
