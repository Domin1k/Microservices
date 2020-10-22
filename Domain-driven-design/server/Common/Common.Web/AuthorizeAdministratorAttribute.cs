namespace PetFoodShop.Web
{
    using Microsoft.AspNetCore.Authorization;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = WebConstants.AuthConstants.AdministratorRoleName;
    }
}
