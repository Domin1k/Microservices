namespace PetFoodShop.Identity.Infrastructure.Persistence.Models
{
    using Application.Contracts;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IApplicationUser
    {
    }
}
