namespace PetFoodShop.Identity.Services
{
    using PetFoodShop.Identity.Data.Models;
    using System.Collections.Generic;

    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
