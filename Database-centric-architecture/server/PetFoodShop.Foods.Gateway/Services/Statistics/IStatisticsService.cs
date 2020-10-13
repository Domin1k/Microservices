namespace PetFoodShop.Foods.Gateway.Services.Statistics
{
    using PetFoodShop.Foods.Gateway.Services.Models.Statistics;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        [Get("/api/v1/foodsviews")]
        Task<IEnumerable<FoodOutputModel>> GetTotalViews([Query(CollectionFormat.Multi)] IEnumerable<int> ids);

        [Get("/api/v1/foodsviews/{id}")]
        Task<int> GetTotalViews(int id);
    }
}
