namespace PetFoodShop.Identity.Infrastructure
{
    using Application.Commands.Common;
    using Application.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Persistence.Models;
    using PetFoodShop.Application;
    using System.Linq;
    using System.Threading.Tasks;

    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly ITokenGeneratorService jwtTokenGenerator;

        public IdentityService(
            UserManager<User> userManager,
            ITokenGeneratorService jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<TokenOutputModel>> Register(UserInputModel userInput)
        {
            var user = new User
            {
                Email = userInput.Email,
                UserName = userInput.Email
            };

            await this.userManager.CreateAsync(user, userInput.Password);

            var data = await this.Login(userInput);
            return  new TokenOutputModel(data.Data.Token);
        }

        public async Task<Result<UserOutputModel>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var roles = await this.userManager.GetRolesAsync(user);

            var token = this.jwtTokenGenerator.GenerateToken(user, roles);

            return new UserOutputModel(user.Id, token);
        }

        public async Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                changePasswordInput.CurrentPassword,
                changePasswordInput.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }
    }
}
