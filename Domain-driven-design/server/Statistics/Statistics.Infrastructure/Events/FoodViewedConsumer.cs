namespace PetFoodShop.Statistics.Infrastructure.Events
{
    using Application;
    using MassTransit;
    using PetFoodShop.Domain.Foods.Events;
    using System.Threading.Tasks;

    public class FoodViewedConsumer : IConsumer<FoodViewedMessage>
    {
        private readonly IStatisticsRepository statisticsRepository;

        public FoodViewedConsumer(IStatisticsRepository statisticsRepository) => this.statisticsRepository = statisticsRepository;

        public async Task Consume(ConsumeContext<FoodViewedMessage> context)
            => await this.statisticsRepository.CreateFoodView(context.Message.FoodId, context.Message.UserId);
    }
}
