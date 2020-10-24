namespace PetFoodShop.Cart.Infrastructure
{
    using System.Collections.Generic;
    using Persistence;
    using PetFoodShop.Domain;
    using PetFoodShop.Infrastructure;

    public class CartDatabaseInitializer : DatabaseInitializer<CartDbContext>
    {
        public CartDatabaseInitializer(CartDbContext db, IEnumerable<IInitialData> initialDataProviders) 
            : base(db, initialDataProviders)
        {
        }
    }
}
