namespace PetFoodShop.Messages
{
    using Hangfire;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PetFoodShop.Data.Models;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MessagesHostedService : IHostedService
    {
        private readonly IRecurringJobManager recurringJobManager;
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IBus bus;

        public MessagesHostedService(
            IRecurringJobManager recurringJobManager,
            IServiceScopeFactory scopeFactory,
            IBus bus)
        {
            this.recurringJobManager = recurringJobManager;
            this.scopeFactory = scopeFactory;
            this.bus = bus;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.recurringJobManager.AddOrUpdate(
                nameof(MessagesHostedService),
                () => this.ProcessPendingMessages(),
                "*/5 * * * * *");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public void ProcessPendingMessages()
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
                

                var pendingMessages = dbContext
                    .Set<Message>()
                    .Where(x => !x.Published)
                    .OrderBy(x => x.Id)
                    .ToList();

                pendingMessages.ForEach(m =>
                {
                    this.bus.Publish(m);
                    m.MarkAsPublished();
                    dbContext.SaveChanges();
                });
            }
        }
    }
}
