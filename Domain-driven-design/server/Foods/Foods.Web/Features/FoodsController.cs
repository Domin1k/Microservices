namespace PetFoodShop.Foods.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Foods.Commands.EditPrice;
    using Application.Foods.Common;
    using Application.Foods.Queries.BrandFoods;
    using Application.Foods.Queries.Details;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Web;
    using PetFoodShop.Web.Controllers.v1;

    public class FoodsController : ApiController
    {
        private const string BrandIdPath = "{brandId}";
        
        [HttpGet(BrandIdPath + PathSeparator + nameof(Brands))]
        [AuthorizeAdministrator]
        public async Task<ActionResult<IEnumerable<BrandFoodsQuery.BrandFoodOutputModel>>> Brands([FromQuery]BrandFoodsQuery query)
            => await this.Send(query);

        [HttpPut(nameof(EditPrice))]
        [AuthorizeAdministrator]
        public async Task<ActionResult<FoodDetailModelOutputModel>> EditPrice(EditPriceCommand command)
            => await this.Send(command);

        [HttpGet(Id)]
        // Depend on Gateway to authorize the user [Authorize]
        public async Task<ActionResult<FoodDetailModelOutputModel>> Details([FromQuery]DetailsQuery query)
            => await this.Send(query);
    }
}
