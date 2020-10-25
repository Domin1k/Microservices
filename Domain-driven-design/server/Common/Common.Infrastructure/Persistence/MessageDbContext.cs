namespace PetFoodShop.Infrastructure.Persistence
{
    using Configuration;
    using Domain.Factories;
    using Domain.Models;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class MessageDbContext : DbContext
    {
        private readonly IBus bus;
        private readonly IMessageFactory messageFactory;
        private readonly Stack<object> savesChangesTracker;

        protected MessageDbContext(DbContextOptions options, IBus bus, IMessageFactory messageFactory)
            : base(options)
        {
            this.bus = bus;
            this.messageFactory = messageFactory;
            this.savesChangesTracker = new Stack<object>();
        }

        public DbSet<Message> Messages { get; set; }

        protected abstract Assembly ConfigurationsAssembly { get; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    var message = this.messageFactory
                        .WithObjectData(domainEvent)
                        .Build();
                    await this.bus.Publish(message, cancellationToken);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());

            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }
    }
}
