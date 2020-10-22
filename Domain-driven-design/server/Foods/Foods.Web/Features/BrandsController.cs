namespace PetFoodShop.Foods.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Web;
    using PetFoodShop.Web.Controllers.v1;
    using System.Threading.Tasks;
    using Application.Categories.Commands.CreateBrand;

    public class BrandsController : ApiController
    {
        
        //public async Task<IActionResult> Create(BrandInputModel model)
        //{
        //    var serviceModel = this.mapper.Map<BrandModel>(model);
        //    var foodBrandId = await this.brandService.Create(serviceModel);
        //    return this.Created($"/foods/{foodBrandId}/brands", foodBrandId);
        //}

        [HttpPost(nameof(Create))]
        [AuthorizeAdministrator]
        public async Task<ActionResult> Create(CreateBrandCommand command)
            => await this.Send(command);
    }
}
