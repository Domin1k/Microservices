namespace PetFoodShop.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;
    using static InfrastructureConstants.AuthConstants;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
    }
}
