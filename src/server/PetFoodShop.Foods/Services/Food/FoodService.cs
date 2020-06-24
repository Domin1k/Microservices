namespace PetFoodShop.Foods.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Foods.Data;
    using PetFoodShop.Foods.Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodService : IFoodService
    {
        private readonly PetFoodDbContext dbContext;
        private readonly IMapper mapper;

        public FoodService(PetFoodDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<FoodDetailModel> DetailsAsync(int foodId)
            => await this.mapper
                        .ProjectTo<FoodDetailModel>(this.dbContext.Foods.Where(x => x.Id == foodId))
                        .FirstOrDefaultAsync();

        public async Task<IEnumerable<FoodModel>> FoodsPerBrand(int brandId)
            => await this.mapper
                        .ProjectTo<FoodModel>(this.dbContext.Foods.Where(x => x.FoodBrandId == brandId))
                        .ToListAsync();
    }
}
