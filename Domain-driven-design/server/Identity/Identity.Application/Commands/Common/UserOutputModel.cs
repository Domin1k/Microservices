namespace PetFoodShop.Identity.Application.Commands.Common
{
    public class UserOutputModel : TokenOutputModel
    {
        public UserOutputModel(string userId, string token)
            : base(token)
        {
            this.UserId = userId;
        }
        public string UserId { get; }
    }
}
