namespace Admin.Startup.Features.Common
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Statistics;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;

        public HomeController(IStatisticsService statistics)
            => this.statistics = statistics;

        public async Task<IActionResult> Index()
        {
            var model = await this.statistics.ShowFullStatistics();
            return this.View("/Features/Common/Views/Home/Index.cshtml", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => this.View(
                "/Features/Common/Views/Shared/Error.cshtml",
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
