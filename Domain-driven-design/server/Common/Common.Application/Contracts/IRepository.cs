namespace PetFoodShop.Application.Contracts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task MarkMessageAsPublished(object id, CancellationToken cancellationToken = default);

        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
