namespace PetFoodShop.Statistics.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Application;
    using Application.Queries.ShowFullStatistics;
    using AutoMapper;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Queries.GetTotalFoodViews;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>, IStatisticsRepository
    {
        private readonly IMapper mapper;

        public StatisticsRepository(IStatisticsDbContext db, IMapper mapper) 
            : base(db) => this.mapper = mapper;

        public async Task<ShowFullStatisticsQuery.FullStatisticsOutputModel> ShowFull(
            CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<ShowFullStatisticsQuery.FullStatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync(cancellationToken);

        public Task<Statistics> Find(CancellationToken cancellationToken)
            => this.All()
                .Include(x => x.FoodViews)
                .SingleOrDefaultAsync(cancellationToken);

        public async Task IncrementTotalFoodBrands(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Find(cancellationToken);
            statistics.IncrementTotalFoodBrands();

            await this.Save(statistics, cancellationToken);
        }

        public async Task CreateFoodView(int foodId, string userId, CancellationToken cancellationToken = default)
        {
            var statistics = await this.Find(cancellationToken);
            statistics.AddFoodView(foodId, userId);
            await this.Save(statistics, cancellationToken);
        }

        public async Task<IEnumerable<GetTotalFoodViewsQuery.TotalFoodViewsOutputModel>> GetTotalFoodsViews(
            IEnumerable<int> ids,
            CancellationToken cancellationToken = default)
        {

            //await this.db.FoodViews
            //.Where(v => ids.Contains(v.FoodId))
            //.GroupBy(v => v.FoodId)
            //.Select(gr => new FoodOutputModel
            //{
            //FoodId = gr.Key,
            //TotalViews = gr.Count()
            //})
            //.ToListAsync();
            return await this.mapper
                .ProjectTo<GetTotalFoodViewsQuery.TotalFoodViewsOutputModel>(
                    this.Data.FoodViews
                        .Where(v => ids.Contains(v.FoodId))
                        .GroupBy(v => v.FoodId)
                        .Select(x => new { FoodId = x.Key, TotalViews = x.Count() })
                    )
                .ToListAsync(cancellationToken);
        }
    }
}