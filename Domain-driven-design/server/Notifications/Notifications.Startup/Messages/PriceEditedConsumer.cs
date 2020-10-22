namespace PetFoodShop.Notifications.Messages
{
    using Domain.Foods.Events;
    using Hub;
    using MassTransit;
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

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
