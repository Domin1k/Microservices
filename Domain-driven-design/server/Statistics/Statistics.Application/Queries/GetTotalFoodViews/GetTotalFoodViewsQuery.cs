namespace PetFoodShop.Statistics.Application.Queries.GetTotalFoodViews
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetTotalFoodViewsQuery : IRequest<IEnumerable<GetTotalFoodViewsQuery.TotalFoodViewsOutputModel>>
    {
        public IEnumerable<int> Ids { get; set; }

        public class TotalFoodViewsOutputModel
        {
            public int FoodId { get; private set; }

            public int TotalViews { get; private set; }
        }

        public class GetTotalFoodViewsQueryHandler : IRequestHandler<GetTotalFoodViewsQuery, IEnumerable<TotalFoodViewsOutputModel>>
        {
            private readonly IStatisticsRepository statisticsRepository;

            public GetTotalFoodViewsQueryHandler(IStatisticsRepository statisticsRepository) => this.statisticsRepository = statisticsRepository;

            public async Task<IEnumerable<TotalFoodViewsOutputModel>> Handle(GetTotalFoodViewsQuery request, CancellationToken cancellationToken) 
                => await this.statisticsRepository.GetTotalFoodsViews(request.Ids, cancellationToken);
        }
    }
}
