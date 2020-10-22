namespace PetFoodShop.Statistics.Application.Queries.ShowFullStatistics
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Models;
    using MediatR;
    using PetFoodShop.Application.Mapping;

    public class ShowFullStatisticsQuery : IRequest<ShowFullStatisticsQuery.FullStatisticsOutputModel>
    {
        public class FullStatisticsOutputModel : IMapFrom<Statistics>
        {
            public int TotalFoodViews { get; set; }

            public int TotalFoodBrands { get; set; }

            public void Mapping(Profile mapper)
                => mapper
                    .CreateMap<Statistics, FullStatisticsOutputModel>()
                    .ForMember(d => d.TotalFoodViews, cfg => cfg.MapFrom(d => d.TotalFoods));
        }

        public class StatisticsOutputModelHandler : IRequestHandler<ShowFullStatisticsQuery, FullStatisticsOutputModel>
        {
            private readonly IStatisticsRepository statisticsRepository;

            public StatisticsOutputModelHandler(IStatisticsRepository statisticsRepository) => this.statisticsRepository = statisticsRepository;

            public async Task<FullStatisticsOutputModel> Handle(ShowFullStatisticsQuery request, CancellationToken cancellationToken)
                => await this.statisticsRepository.ShowFull(cancellationToken);
        }
    }
}
