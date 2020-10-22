namespace PetFoodShop.Statistics.Web.Features
{
    using System.Threading.Tasks;
    using Application.Queries.ShowFullStatistics;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Web.Controllers.v1;

    public class StatisticsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<ShowFullStatisticsQuery.FullStatisticsOutputModel>> ShowFullStatistics(
            [FromQuery] ShowFullStatisticsQuery query)
            => await this.Send(query);
    }
}
