namespace PetFoodShop.Statistics.Services
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Statistics.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class StatisticsService : IStatisticsService
    {
        private readonly StatisticsDbContext db;

        public StatisticsService(StatisticsDbContext db)
        {
            this.db = db;
        }

        public async Task<StatisticsOutputModel> Full()
            => await this.db
                .Statistics
                .Select(x => new StatisticsOutputModel
                {
                    TotalFoodBrands = x.TotalFoodBrands,
                    TotalFoodViews = x.TotalFoods
                })
                .SingleOrDefaultAsync();

    }
}
