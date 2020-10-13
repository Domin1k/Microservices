namespace PetFoodShop.Foods.Controllers.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BrandInputModel
    {
        [Required]
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
    }
}
