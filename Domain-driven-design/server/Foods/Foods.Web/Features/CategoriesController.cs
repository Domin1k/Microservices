namespace PetFoodShop.Foods.Web.Features
{
    using Application.Categories.Queries.All;
    using Application.Categories.Queries.CategoryBrands;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Web.Controllers.v1;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoriesController : ApiController
    {
        [HttpGet(nameof(All))]
        public async Task<ActionResult<IEnumerable<AllCategoriesQuery.AllCategoryOutputModel>>> All([FromQuery]AllCategoriesQuery query)
            => await this.Send(query);

        [HttpGet(Id + PathSeparator + nameof(Brands))]
        public async Task<ActionResult<FoodCategoryBrandOutputModel>> Brands([FromRoute] CategoryBrandQuery query)
            => await this.Send((query));
    }
}
