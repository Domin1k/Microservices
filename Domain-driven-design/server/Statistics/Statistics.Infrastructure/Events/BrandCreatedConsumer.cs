namespace PetFoodShop.Statistics.Infrastructure.Events
{
    using System.Threading.Tasks;
    using Application;
    using MassTransit;
    using PetFoodShop.Domain.Foods.Events;

    public class BrandCreatedConsumer : IConsumer<BrandCreatedMessage>
    {
        private readonly IStatisticsRepository statisticsRepository;

        public BrandCreatedConsumer(IStatisticsRepository statisticsRepository) => this.statisticsRepository = statisticsRepository;

        public async Task Consume(ConsumeContext<BrandCreatedMessage> context)
            => await this.statisticsRepository.IncrementTotalFoodBrands();
    }
}
