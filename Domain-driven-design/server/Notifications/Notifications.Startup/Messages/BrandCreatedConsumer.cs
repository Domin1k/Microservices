namespace PetFoodShop.Notifications.Messages
{
    using Domain.Foods.Events;
    using MassTransit;
    using Microsoft.AspNetCore.SignalR;
    using PetFoodShop.Notifications.Hub;
    using System.Threading.Tasks;

    public class BrandCreatedConsumer : IConsumer<BrandCreatedMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public BrandCreatedConsumer(IHubContext<NotificationsHub> hub)
            => this.hub = hub;

        public async Task Consume(ConsumeContext<BrandCreatedMessage> context)
            => await this.hub
                .Clients
                .Groups(Constants.AuthenticatedUsersGroup)
                .SendAsync(Constants.ReceiveNotificationEndpointBrandAdded, context.Message);
    }
}
