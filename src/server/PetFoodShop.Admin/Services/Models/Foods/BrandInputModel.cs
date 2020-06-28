using System.ComponentModel.DataAnnotations;

namespace PetFoodShop.Admin.Services.Models.Foods
{
    public class BrandInputModel
    {
        public BrandInputModel(string name, int foodCategoryId)
        {
            Name = name;
            FoodCategoryId = foodCategoryId;
        }

        [Required]
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
    }
}
