namespace PetFoodShop.Foods.Services
{
    using AutoMapper;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Foods.Data;
    using PetFoodShop.Foods.Services.Models;
    using PetFoodShop.Messages.Foods;
    using PetFoodShop.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodService : IFoodService
    {
        private readonly FoodDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IBus bus;
        private readonly ICurrentUserService currentUserService;

        public FoodService(
            FoodDbContext dbContext, 
            IMapper mapper, 
            IBus bus,
            ICurrentUserService currentUserService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.bus = bus;
            this.currentUserService = currentUserService;
        }

        public async Task<FoodDetailModel> DetailsAsync(int foodId)
        {
            await this.bus.Publish(new FoodViewedMessage
            {
                FoodId = foodId,
                UserId = this.currentUserService.UserId
            });
            return await this.mapper
                        .ProjectTo<FoodDetailModel>(this.dbContext.Foods.Where(x => x.Id == foodId))
                        .FirstOrDefaultAsync();
        }

        public async Task<FoodDetailModel> EditPrice(int foodId, decimal price)
        {
            var food = await this.dbContext.Foods.FirstOrDefaultAsync(f => f.Id == foodId);
            if (food == null)
            {
                return null;
            }

            food.Price = price;
            this.dbContext.Foods.Update(food);
            await this.dbContext.SaveChangesAsync();
            await this.bus.Publish(new PriceEditedMessage
            {
                FoodId = food.Id,
                Price = food.Price
            });
            return this.mapper.Map<FoodDetailModel>(food);
        }

        public async Task<IEnumerable<FoodModel>> FoodsPerBrand(int brandId)
            => await this.mapper
                        .ProjectTo<FoodModel>(this.dbContext.Foods.Where(x => x.FoodBrandId == brandId))
                        .ToListAsync();
    }
}
