namespace PetFoodShop.Statistics.Services
{
    using PetFoodShop.Statistics.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodViewService
    {
        Task<int> GetTotalViews(int foodId);

        Task<IEnumerable<FoodOutputModel>> GetTotalViews(IEnumerable<int> ids);
    }
}
