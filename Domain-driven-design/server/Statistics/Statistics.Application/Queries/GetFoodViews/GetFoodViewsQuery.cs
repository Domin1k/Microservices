namespace PetFoodShop.Statistics.Application.Queries.GetFoodViews
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using PetFoodShop.Application;

    public class GetFoodViewsQuery : IRequest<Result<int>>
    {
        public int FoodId { get; set; }

        public class GetFoodViewsQueryHandler: IRequestHandler<GetFoodViewsQuery, Result<int>>
        {
            private readonly IStatisticsRepository statisticsRepository;

            public GetFoodViewsQueryHandler(IStatisticsRepository statisticsRepository) => this.statisticsRepository = statisticsRepository;

            public async Task<Result<int>> Handle(GetFoodViewsQuery request, CancellationToken cancellationToken)
            {
                var statistics = await this.statisticsRepository.Find(cancellationToken);

                return Result<int>.SuccessWith(statistics.GetTotalViewPerFood(request.FoodId));
            }
        }
    }
}
