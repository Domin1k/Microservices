namespace PetFoodShop.Statistics.Messages
{
    using MassTransit;
    using PetFoodShop.Messages.Foods;
    using PetFoodShop.Statistics.Services;
    using System.Threading.Tasks;

    public class FoodViewedConsumer : IConsumer<FoodViewedMessage>
    {
        private readonly IFoodViewService foodViewService;

        public FoodViewedConsumer(IFoodViewService foodViewService)
        {
            this.foodViewService = foodViewService;
        }
        public async Task Consume(ConsumeContext<FoodViewedMessage> context)
            => await this.foodViewService.AddFoodView(context.Message.FoodId, context.Message.UserId);
    }
}
