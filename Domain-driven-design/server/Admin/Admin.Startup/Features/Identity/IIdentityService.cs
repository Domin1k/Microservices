namespace PetFoodShop.Admin.Startup.Features.Identity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Refit;

    public interface IIdentityService
    {
        [Post("/api/v1/Identity/Login")]
        Task<UserOutputModel> Login(UserInputModel command);
    }
}
