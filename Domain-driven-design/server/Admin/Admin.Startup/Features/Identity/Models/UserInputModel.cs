namespace Admin.Startup.Features.Identity.Models
{
    using PetFoodShop.Application.Mapping;

    public class UserInputModel : IMapFrom<LoginCommandInputModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
