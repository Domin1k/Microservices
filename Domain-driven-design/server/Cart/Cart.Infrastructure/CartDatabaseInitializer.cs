namespace PetFoodShop.Cart.Infrastructure
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using PetFoodShop.Domain;
    using PetFoodShop.Infrastructure;

    public class CartDatabaseInitializer : DatabaseInitializer<CartDbContext>
    {
        public CartDatabaseInitializer(CartDbContext db, IEnumerable<IInitialData> initialDataProviders) 
            : base(db, initialDataProviders)
        {
        }

        protected override DbSet<TEntity> GetSet<TEntity>()
            => this.Db.Set<TEntity>();
    }
}
