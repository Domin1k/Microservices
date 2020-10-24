namespace PetFoodShop.Identity.Infrastructure
{
    using System.Collections.Generic;
    using Domain;
    using Persistence;
    using PetFoodShop.Infrastructure;

    public class IdentityDatabaseInitializer : DatabaseInitializer<AppIdentityDbContext>
    {
        public IdentityDatabaseInitializer(AppIdentityDbContext db, IEnumerable<IInitialData> initialDataProviders) 
            : base(db, initialDataProviders)
        {
        }
    }
}
