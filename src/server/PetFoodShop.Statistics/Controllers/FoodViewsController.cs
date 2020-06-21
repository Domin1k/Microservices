namespace PetFoodShop.Statistics.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Statistics.Services;
    using PetFoodShop.Statistics.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("foodsviews")]
    public class FoodViewsController : ApiController
    {
        private readonly IFoodViewService foodViews;

        public FoodViewsController(IFoodViewService foodViews)
        {
            this.foodViews = foodViews;
        }

        [HttpGet]
        [Route("Id")]
        public async Task<int> TotalViews(int id)
            => await this.foodViews.GetTotalViews(id);

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<FoodOutputModel>> TotalViews(
            [FromQuery] IEnumerable<int> ids)
            => await this.foodViews.GetTotalViews(ids);
    }
}
