namespace Admin.Startup.Features.FoodCategories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Refit;

    public interface IFoodCategoryService
    {
        [Get("/api/v1/categories/all")]
        Task<IEnumerable<AllCategoryOutputModel>> All();

        [Get("/api/v1/categories/{id}/brands")]
        Task<IEnumerable<FoodCategoryBrandOutputModel>> Brands(int id);

        [Post("/api/v1/brands/create")]
        Task CreateBrand([FromBody] CreateBrandCommand command);
    }
}
