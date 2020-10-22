namespace PetFoodShop.Application.Contracts
{
    using System.Threading.Tasks;
    using Domain.Events;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
