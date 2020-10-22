namespace PetFoodShop.Gateway.Startup.Features.Statistics
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Refit;

    public interface IStatisticsService
    {
        [Get("/api/v1/foodsviews")]
        Task<IEnumerable<TotalFoodViewsOutputModel>> GetTotalViews([Query(CollectionFormat.Multi)] IEnumerable<int> ids);

        [Get("/api/v1/foodsviews/{id}")]
        Task<int> GetTotalViews(int id);
    }
}
