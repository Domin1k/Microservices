namespace PetFoodShop.Gateway.Startup.Features.FoodCategories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Refit;

    public interface IFoodCategoriesService
    {
        [Get("/api/v1/categories/all")]
        Task<IEnumerable<AllCategoryOutputModel>> All();

        [Get("/api/v1/categories/{id}/brands")]
        Task<IEnumerable<FoodCategoryBrandOutputModel>> Brands(int id);
    }
}
