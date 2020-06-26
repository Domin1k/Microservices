namespace PetFoodShop.Admin.Services.Models.Identity
{
    using PetFoodShop.Services.Identity;
    using System.ComponentModel.DataAnnotations;

    public class LoginFormModel
    {
        [EmailAddress]
        [Required]
        [MinLength(IdentityValidation.MinEmailLength)]
        [MaxLength(IdentityValidation.MaxEmailLength)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
