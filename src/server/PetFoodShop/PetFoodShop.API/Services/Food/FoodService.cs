namespace PetFoodShop.API.Services
{
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.API.Data;
    using PetFoodShop.API.Services.Models.Food;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodService : IFoodService
    {
        private readonly PetFoodDbContext dbContext;

        public FoodService(PetFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<FoodDetailModel> DetailsAsync(int foodId)
            => await this.dbContext.Foods
                    .Where(x => x.Id == foodId)
                    .Select(x => new FoodDetailModel
                    {
                        Id = x.Id,
                        Description = x.Description,
                        FoodBrandId = x.FoodBrandId,
                        Image = x.Image,
                        Name = x.Name,
                        Price = x.Price,
                        Quantity = x.Quantity
                    })
                    .FirstOrDefaultAsync();

        public async Task<IEnumerable<FoodModel>> FoodsPerBrand(int brandId)
            => await this.dbContext.Foods
                    .Where(x => x.FoodBrandId == brandId)
                    .Select(x => new FoodModel
                    {
                        Id = x.Id,
                        FoodBrandId = x.FoodBrandId,
                        Image = x.Image,
                        Name = x.Name,
                        Price = x.Price,
                    })
                    .ToListAsync();
    }
}
