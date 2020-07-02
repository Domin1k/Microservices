namespace PetFoodShop.Statistics.Services
{
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Statistics.Services.Models;
    using System.Threading.Tasks;

    public class StatisticsService : IStatisticsService
    {
        private readonly StatisticsDbContext db;
        private readonly IMapper mapper;

        public StatisticsService(StatisticsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<StatisticsOutputModel> Full()
            => await this.mapper
                        .ProjectTo<StatisticsOutputModel>(this.db.Statistics)
                        .SingleOrDefaultAsync();

        public async Task IncrementBrandStatistics()
        {
            var statistics = await this.db.Statistics.SingleOrDefaultAsync();

            statistics.TotalFoodBrands++;

            this.db.Statistics.Update(statistics);
            await this.db.SaveChangesAsync();
        }
    }
}
