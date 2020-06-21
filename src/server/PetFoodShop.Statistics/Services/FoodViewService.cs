namespace PetFoodShop.Statistics.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Statistics.Data;
    using PetFoodShop.Statistics.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodViewService : IFoodViewService
    {
        private readonly StatisticsDbContext db;

        public FoodViewService(StatisticsDbContext db)
        {
            this.db = db;
        }

        public async Task<int> GetTotalViews(int foodId)
            => await this.db.FoodViews
                        .CountAsync(v => v.FoodId== foodId);

        public async Task<IEnumerable<FoodOutputModel>> GetTotalViews(IEnumerable<int> ids)
            => await this.db.FoodViews
                .Where(v => ids.Contains(v.FoodId))
                .GroupBy(v => v.FoodId)
                .Select(gr => new FoodOutputModel
                {
                    FoodId = gr.Key,
                    TotalViews = gr.Count()
                })
                .ToListAsync();
    }
}
