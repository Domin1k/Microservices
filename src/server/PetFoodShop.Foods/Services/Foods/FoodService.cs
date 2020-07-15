namespace PetFoodShop.Foods.Services
{
    using AutoMapper;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Data.Models;
    using PetFoodShop.Foods.Data;
    using PetFoodShop.Foods.Data.Models;
    using PetFoodShop.Foods.Services.Models;
    using PetFoodShop.Messages.Foods;
    using PetFoodShop.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodService : DataService<Food>, IFoodService
    {
        private readonly IMapper mapper;
        private readonly IBus bus;
        private readonly ICurrentUserService currentUserService;

        public FoodService(
            FoodDbContext dbContext, 
            IMapper mapper, 
            IBus bus,
            ICurrentUserService currentUserService)
                :base(dbContext)
        {
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
                        .ProjectTo<FoodDetailModel>(this.All().Where(x => x.Id == foodId))
                        .FirstOrDefaultAsync();
        }

        public async Task<FoodDetailModel> EditPrice(int foodId, decimal price)
        {
            var food = await this.Data.FindAsync<Food>(foodId);
            if (food == null)
            {
                return null;
            }

            food.Price = price;
            this.Data.Update(food);
            var message = new PriceEditedMessage
            {
                FoodId = food.Id,
                Price = food.Price
            };

            await this.Save(food, new Message(message));
            await this.bus.Publish(message);
            await this.MarkMessageAsPublished(food.Id);

            return this.mapper.Map<FoodDetailModel>(food);
        }

        public async Task<IEnumerable<FoodModel>> FoodsPerBrand(int brandId)
            => await this.mapper
                        .ProjectTo<FoodModel>(this.All().Where(x => x.FoodBrandId == brandId))
                        .ToListAsync();
    }
}
