namespace Admin.Startup.Features.Foods
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Refit;

    public interface IFoodService
    {
        [Put("/api/v1/foods/editPrice")]
        Task EditPrice([FromBody] EditPriceCommand command);

        [Get("/api/v1/foods/{id}/brands")]
        Task<IEnumerable<BrandFoodOutputModel>> Brands(int id);
    }
}
