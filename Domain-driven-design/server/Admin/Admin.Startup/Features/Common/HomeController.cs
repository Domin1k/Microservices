namespace PetFoodShop.Admin.Startup.Features.Common
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Statistics;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;

        public HomeController(IStatisticsService statistics)
            => this.statistics = statistics;

        public async Task<IActionResult> Index()
        {
            var model = await this.statistics.ShowFullStatistics();
            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
