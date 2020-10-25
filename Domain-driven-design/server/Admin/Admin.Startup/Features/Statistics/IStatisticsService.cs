namespace PetFoodShop.Admin.Startup.Features.Statistics
{
    using System.Threading.Tasks;
    using Models;
    using Refit;

    public interface IStatisticsService
    {
        [Get("/api/v1/Statistics")]
        Task<FullStatisticsOutputModel> ShowFullStatistics();
    }
}
