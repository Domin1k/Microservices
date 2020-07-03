namespace PetFoodShop.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Models;
    using PetFoodShop.Admin.Services.Statistics;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;

        public HomeController(IStatisticsService statistics)
            => this.statistics = statistics;

        public async Task<IActionResult> Index()
        {
            var model = await this.statistics.Full();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
