namespace PetFoodShop.Statistics.Infrastructure
{
    using System.Collections.Generic;
    using Persistence;
    using PetFoodShop.Domain;
    using PetFoodShop.Infrastructure;

    public class StatisticsDatabaseInitializer : DatabaseInitializer<StatisticsDbContext>
    {
        public StatisticsDatabaseInitializer(StatisticsDbContext db, IEnumerable<IInitialData> initialDataProviders)
            : base(db, initialDataProviders)
        {
        }
    }
}
