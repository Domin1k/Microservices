namespace PetFoodShop.Foods.Infrastructure.Categories.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Categories;
    using Application.Categories.Queries.All;
    using Application.Categories.Queries.CategoryBrands;
    using AutoMapper;
    using Domain.Categories.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure;

    internal class FoodCategoriesRepository : DataRepository<IFoodCategoryDbContext, FoodCategory>, IFoodCategoriesRepository
    {
        private readonly IMapper mapper;
        public FoodCategoriesRepository(IFoodCategoryDbContext db, IMapper mapper)
            : base(db) => this.mapper = mapper;

        public Task<FoodCategory> Find(int id, CancellationToken cancellationToken)
           => this.All()
                  .Include(x => x.Brands)
                  .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IEnumerable<CategoryBrandQuery.FoodCategoryBrandOutputModel>> FindCategoryBrands(
            int id,
            CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<CategoryBrandQuery.FoodCategoryBrandOutputModel>(
                    this.All().Where(x => x.Id == id).Select(x => x.Brands))
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<AllCategoriesQuery.AllCategoryOutputModel>> All(CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<AllCategoriesQuery.AllCategoryOutputModel>(this.Data.FoodCategories)
                .ToListAsync(cancellationToken);
    }
}
