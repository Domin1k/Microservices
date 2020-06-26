namespace PetFoodShop.Foods.Gateway.Services.Statistics
{
    using PetFoodShop.Foods.Gateway.Services.Models.Statistics;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        [Get("/foodsviews")]
        Task<IEnumerable<FoodOutputModel>> GetTotalViews([Query(CollectionFormat.Multi)] IEnumerable<int> ids);

        [Get("/foodsviews/{id}")]
        Task<int> GetTotalViews(int id);
    }
}
