namespace PetFoodShop.Foods.Infrastructure
{
    using System.Collections.Generic;
    using Common.Persistence;
    using PetFoodShop.Domain;
    using PetFoodShop.Infrastructure;

    public class FoodsDatabaseInitializer : DatabaseInitializer<FoodDbContext>
    {
        public FoodsDatabaseInitializer(FoodDbContext db, IEnumerable<IInitialData> initialDataProviders)
            : base(db, initialDataProviders)
        {
        }
    }
}
