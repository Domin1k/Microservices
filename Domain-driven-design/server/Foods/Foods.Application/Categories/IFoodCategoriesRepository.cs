namespace PetFoodShop.Foods.Application.Categories
{
    using Domain.Categories.Models;
    using PetFoodShop.Application.Contracts;
    using Queries.All;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Queries.CategoryBrands;

    public interface IFoodCategoriesRepository : IRepository<FoodCategory>
    {
        Task<FoodCategory> Find(int id, CancellationToken cancellationToken);

        Task<IEnumerable<CategoryBrandQuery.FoodCategoryBrandOutputModel>> FindCategoryBrands(int id, CancellationToken cancellationToken);

        Task<IEnumerable<AllCategoriesQuery.AllCategoryOutputModel>> All(CancellationToken cancellationToken);
    }
}
