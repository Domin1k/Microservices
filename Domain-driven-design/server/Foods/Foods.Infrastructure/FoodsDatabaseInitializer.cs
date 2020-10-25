namespace PetFoodShop.Foods.Infrastructure
{
    using System.Collections.Generic;
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Domain;
    using PetFoodShop.Infrastructure;

    public class FoodsDatabaseInitializer : DatabaseInitializer<FoodDbContext>
    {
        public FoodsDatabaseInitializer(FoodDbContext db, IEnumerable<IInitialData> initialDataProviders)
            : base(db, initialDataProviders)
        {
        }

        protected override DbSet<TEntity> GetSet<TEntity>()
            => this.Db.Set<TEntity>();
    }
}
