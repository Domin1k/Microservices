namespace PetFoodShop.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Services.Statistics;
    using System.Threading.Tasks;

    public class StatisticsController : AdministrationController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
            => this.statistics = statistics;

        public async Task<IActionResult> Index()
        {
            var model = await this.statistics.Full();
            return View(model);
        }
    }
}
