namespace PetFoodShop.Statistics.Messages
{
    using MassTransit;
    using PetFoodShop.Messages.Foods;
    using PetFoodShop.Statistics.Services;
    using System;
    using System.Threading.Tasks;

    public class BrandCreatedConsumer : IConsumer<BrandCreatedMessage>
    {
        private readonly IStatisticsService statisticsService;

        public BrandCreatedConsumer(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        public async Task Consume(ConsumeContext<BrandCreatedMessage> context)
            => await this.statisticsService.IncrementBrandStatistics();
    }
}
