namespace PetFoodShop.Admin.Services.Models.Foods
{
    using System.ComponentModel.DataAnnotations;

    public class BrandInputModel
    {
        [Required]
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
    }
}
