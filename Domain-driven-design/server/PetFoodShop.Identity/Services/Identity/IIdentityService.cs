namespace PetFoodShop.Identity.Services.Identity
{
    using PetFoodShop.Identity.Data.Models;
    using PetFoodShop.Identity.Services.Models;
    using PetFoodShop.Services;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
