namespace PetFoodShop.Foods.Application.Foods
{
    using Common;
    using Domain.Foods.Models;
    using PetFoodShop.Application.Contracts;
    using Queries.BrandFoods;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFoodsRepository : IRepository<Food>
    {
        Task<Food> Find(int id, CancellationToken cancellationToken);

        Task<FoodDetailModelOutputModel> Details(int id, CancellationToken cancellationToken);

        Task<IEnumerable<BrandFoodsQuery.BrandFoodOutputModel>> BrandFoods(int brandId, CancellationToken cancellationToken);
    }
}
