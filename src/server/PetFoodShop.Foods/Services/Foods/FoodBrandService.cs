namespace PetFoodShop.Foods.Services
{
    using MassTransit;
    using Microsoft.EntityFrameworkCore.Internal;
    using PetFoodShop.Data.Models;
    using PetFoodShop.Foods.Data;
    using PetFoodShop.Foods.Data.Models;
    using PetFoodShop.Foods.Infrastructure.Exceptions;
    using PetFoodShop.Foods.Services.Models.FoodBrand;
    using PetFoodShop.Messages.Foods;
    using PetFoodShop.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodBrandService : DataService<FoodBrand>, IFoodBrandService
    {
        private readonly IBus bus;

        public FoodBrandService(FoodDbContext dbContext, IBus bus)
            : base(dbContext)
        {
            this.bus = bus;
        }

        public async Task<int> Create(BrandModel model)
        {
            if (this.All().Any(b => b.Name.ToLower() == model.Name.ToLower()))
            {
                throw new CreateBrandException($"Brand - {model.Name} already exists");
            }

            if (!this.All().Any(c => c.FoodCategoryId == model.FoodCategoryId))
            {
                throw new FoodCategoryNotFoundException($"Category does not exists");
            }

            var brand = new FoodBrand
            {
                Name = model.Name,
                FoodCategoryId = model.FoodCategoryId
            };
            var eventMessage = new BrandCreatedMessage
            {
                BrandId = brand.Id,
                BrandName = brand.Name
            };
            var message = new Message(eventMessage);
            await this.Save(brand, message);
            await this.bus.Publish(eventMessage);
            await this.MarkMessageAsPublished(message.Id);

            return brand.Id;
        }
    }
}
