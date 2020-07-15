namespace PetFoodShop.Foods.Services
{
    using MassTransit;
    using Microsoft.EntityFrameworkCore.Internal;
    using PetFoodShop.Foods.Data;
    using PetFoodShop.Foods.Data.Models;
    using PetFoodShop.Foods.Infrastructure.Exceptions;
    using PetFoodShop.Foods.Services.Models.FoodBrand;
    using PetFoodShop.Messages.Foods;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodBrandService : IFoodBrandService
    {
        private readonly FoodDbContext dbContext;
        private readonly IBus bus;

        public FoodBrandService(FoodDbContext dbContext, IBus bus)
        {
            this.dbContext = dbContext;
            this.bus = bus;
        }

        public async Task<int> Create(BrandModel model)
        {
            if (this.dbContext.FoodBrands.Any(b => b.Name.ToLower() == model.Name.ToLower()))
            {
                throw new CreateBrandException($"Brand - {model.Name} already exists");
            }

            if (!this.dbContext.FoodCategories.Any(c => c.Id == model.FoodCategoryId))
            {
                throw new FoodCategoryNotFoundException($"Category does not exists");
            }

            var brand = new FoodBrand
            {
                Name = model.Name,
                FoodCategoryId = model.FoodCategoryId
            };
            this.dbContext.FoodBrands.Add(brand);

            await this.dbContext.SaveChangesAsync();
            await this.bus.Publish(new BrandCreatedMessage
            {
                BrandId = brand.Id,
                BrandName = brand.Name
            });
            return brand.Id;
        }
    }
}
