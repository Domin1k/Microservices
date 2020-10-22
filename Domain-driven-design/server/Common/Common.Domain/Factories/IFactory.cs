namespace PetFoodShop.Domain.Factories
{
    using Models;

    public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
