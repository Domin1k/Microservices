namespace PetFoodShop.Admin.Services.Models.Identity
{
    using PetFoodShop.Models;

    public class UserInputModel : IMapFrom<LoginFormModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
