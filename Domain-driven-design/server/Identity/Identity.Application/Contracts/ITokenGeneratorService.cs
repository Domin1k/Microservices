namespace PetFoodShop.Identity.Application.Contracts
{
    using System.Collections.Generic;

    public interface ITokenGeneratorService
    {
        string GenerateToken(IApplicationUser user, IEnumerable<string> roles = null);
    }
}
