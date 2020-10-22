namespace PetFoodShop.Infrastructure.Events
{
    using System.Threading.Tasks;
    using Domain.Events;

    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
