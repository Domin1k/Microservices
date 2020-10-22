namespace PetFoodShop.Infrastructure.Persistence.Models
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;
    using Hangfire;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class MessagesHostedService : IHostedService
    {
        private const string FiveSecondsCronExpression = "*/5 * * * * *";

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
                () => this.ProcessPendingMessages(cancellationToken),
                FiveSecondsCronExpression);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public void ProcessPendingMessages(CancellationToken cancellationToken)
        {
            using var scope = this.scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
                

            var pendingMessages = dbContext
                .Set<Message>()
                .Where(x => !x.Published)
                .OrderBy(x => x.Id)
                .ToList();

            foreach (var m in pendingMessages)
            {
                this.bus.Publish(m.Data, m.Type, cancellationToken).GetAwaiter().GetResult();
                m.MarkAsPublished();
                dbContext.SaveChanges();
            }
        }
    }
}
