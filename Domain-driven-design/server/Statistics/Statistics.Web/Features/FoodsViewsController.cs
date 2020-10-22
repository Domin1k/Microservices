namespace PetFoodShop.Statistics.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Queries.GetFoodViews;
    using Application.Queries.GetTotalFoodViews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Web.Controllers.v1;

    public class FoodsViewsController : ApiController
    {
        [HttpGet(Id)]
        public async Task<ActionResult<int>> GetTotalFoodViews(
            [FromQuery] GetFoodViewsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetTotalFoodViewsQuery.TotalFoodViewsOutputModel>>> GetTotalFoodViews(
            [FromQuery] GetTotalFoodViewsQuery query)
            => await this.Send(query);
    }
}
