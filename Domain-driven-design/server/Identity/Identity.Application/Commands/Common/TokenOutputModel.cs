namespace PetFoodShop.Identity.Application.Commands.Common
{
    public class TokenOutputModel
    {
        public TokenOutputModel(string token) => this.Token = token;

        public string Token { get; }
    }
}
