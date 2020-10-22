namespace PetFoodShop.Statistics.Application
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;
    using PetFoodShop.Application.Contracts;
    using Queries.GetTotalFoodViews;
    using Queries.ShowFullStatistics;

    public interface IStatisticsRepository : IRepository<Statistics>
    {
        Task<ShowFullStatisticsQuery.FullStatisticsOutputModel> ShowFull(CancellationToken cancellationToken = default);

        Task<Statistics> Find(CancellationToken cancellationToken = default);

        Task IncrementTotalFoodBrands(CancellationToken cancellationToken = default);

        Task CreateFoodView(int foodId, string userId, CancellationToken cancellationToken = default);

        Task<IEnumerable<GetTotalFoodViewsQuery.TotalFoodViewsOutputModel>> GetTotalFoodsViews(
            IEnumerable<int> ids,
            CancellationToken cancellationToken = default);
    }
}
