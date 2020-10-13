namespace PetFoodShop.Notifications.Messages
{
    using System.Threading.Tasks;
    using Hub;
    using MassTransit;
    using Microsoft.AspNetCore.SignalR;
    using PetFoodShop.Messages.Foods;

    public class PriceEditedConsumer : IConsumer<PriceEditedMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public PriceEditedConsumer(IHubContext<NotificationsHub> hub)
            => this.hub = hub;

        public async Task Consume(ConsumeContext<PriceEditedMessage> context)
            => await this.hub
                .Clients
                .Groups(Constants.AuthenticatedUsersGroup)
                .SendAsync(Constants.ReceiveNotificationEndpointPriceChanged, context.Message);
    }
}
