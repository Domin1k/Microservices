namespace PetFoodShop.Identity.Application.Contracts
{
    using Commands.Common;
    using PetFoodShop.Application;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        Task<Result<TokenOutputModel>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
