namespace PetFoodShop.Application.Contracts
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task MarkMessageAsPublished(int id);

        Task Save(TEntity entity, params Message[] messages);
    }
}
