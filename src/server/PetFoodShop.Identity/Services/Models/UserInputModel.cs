namespace PetFoodShop.Identity.Services.Models
{
    using PetFoodShop.Services.Identity;
    using System.ComponentModel.DataAnnotations;

    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(IdentityValidation.MinEmailLength)]
        [MaxLength(IdentityValidation.MaxEmailLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
