namespace PetFoodShop.Statistics.Services
{
    using PetFoodShop.Statistics.Services.Models;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        Task<StatisticsOutputModel> Full();
    }
}
