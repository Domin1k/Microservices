namespace PetFoodShop.Cart.Infrastructure.Persistence.Repositories
{
    using Application.Contracts;
    using Domain.Models;
    using PetFoodShop.Infrastructure;

    internal class CartRepository : DataRepository<ICartDbContext, Shipment>, ICartRepository
    {
        public CartRepository(ICartDbContext db) 
            : base(db)
        {
        }
    }
}
