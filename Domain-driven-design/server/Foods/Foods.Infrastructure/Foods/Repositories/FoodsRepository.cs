namespace PetFoodShop.Foods.Infrastructure.Foods.Repositories
{
    using Application.Foods;
    using Application.Foods.Common;
    using Application.Foods.Queries.BrandFoods;
    using AutoMapper;
    using Domain.Foods.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class FoodsRepository : DataRepository<IFoodDbContext, Food>, IFoodsRepository
    {
        private readonly IMapper mapper;

        public FoodsRepository(IFoodDbContext db, IMapper mapper) 
            : base(db) => this.mapper = mapper;

        public Task<Food> Find(int id, CancellationToken cancellationToken)
            => this.All().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<FoodDetailModelOutputModel> Details(int id, CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<FoodDetailModelOutputModel>(
                    this.All().Where(x => x.Id == id))
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<BrandFoodsQuery.BrandFoodOutputModel>> BrandFoods(
            int brandId,
            CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<BrandFoodsQuery.BrandFoodOutputModel>(
                    this.Data.Foods.Where(x => x.BrandId == brandId))
                .ToListAsync(cancellationToken);

    }
}
