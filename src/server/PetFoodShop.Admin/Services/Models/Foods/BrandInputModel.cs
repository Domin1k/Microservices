using System.ComponentModel.DataAnnotations;

namespace PetFoodShop.Admin.Services.Models.Foods
{
    public class BrandInputModel
    {
        [Required]
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
    }
}
