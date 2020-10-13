namespace PetFoodShop.Admin.Services.Statistics
{
    using System.Threading.Tasks;
    using Models.Statistics;
    using Refit;

    public interface IStatisticsService
    {
        [Get("/api/v1/Statistics")]
        Task<StatisticsOutputModel> Full();
    }
}
