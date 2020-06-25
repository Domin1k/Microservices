namespace PetFoodShop.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute()
            => this.Roles = InfrastructureConstants.AdministratorRoleName;
    }
}
