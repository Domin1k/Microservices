namespace PetFoodShop.Statistics.Data
{
    using PetFoodShop.Services;
    using System;
    using System.Linq;

    public class StatisticsDataSeeder : IDataSeeder
    {
        private readonly StatisticsDbContext dbContext;

        public StatisticsDataSeeder(StatisticsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SeedData()
        {
            if (this.dbContext.Statistics.Any())
            {
                return;
            }

            var statistics = new Data.Models.Statistics
            {
                TotalFoodBrands = 0,
                TotalFoods = 0
            };

            this.dbContext.Statistics.Add(statistics);
            this.dbContext.SaveChanges();
        }
    }
}
