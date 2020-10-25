namespace PetFoodShop.Infrastructure
{
    using Application.Contracts;
    using Domain.Models;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class DataRepository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => this.Data = db;

        protected TDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task MarkMessageAsPublished(object id, CancellationToken cancellationToken = default)
        {
            var message = await this.Data.Set<Message>().FindAsync(id);

            message.MarkAsPublished();

            await this.Data.SaveChangesAsync(cancellationToken);
        }

        public async Task Save(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
