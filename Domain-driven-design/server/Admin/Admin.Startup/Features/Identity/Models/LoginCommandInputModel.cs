namespace PetFoodShop.Admin.Startup.Features.Identity.Models
{
    public class LoginCommandInputModel
    {
        //[EmailAddress]
        //[Required]
        //[MinLength(ModelConstants.Common.MinEmailLength)]
        //[MaxLength(ModelConstants.Common.MaxEmailLength)]
        //[Display(Name = "Email Address")]
        public string Email { get; set; }

        //[Required]
        public string Password { get; set; }
    }
}
