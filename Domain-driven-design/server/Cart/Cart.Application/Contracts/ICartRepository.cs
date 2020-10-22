namespace PetFoodShop.Cart.Application.Contracts
{
    using Domain.Models;
    using PetFoodShop.Application.Contracts;

    public interface ICartRepository : IRepository<Shipment>
    {
    }
}
