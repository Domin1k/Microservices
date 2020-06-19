using System.ComponentModel.DataAnnotations;

namespace PetFoodShop.Foods.Data.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Validation.Common.MinNameLength)]
        [MaxLength(Validation.Common.MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(Validation.Food.MaxDescriptionLength)]
        public string Description { get; set; }

        [Range(Validation.Food.MinQuantity, Validation.Food.MaxQuantity)]
        public int Quantity { get; set; }

        [Range(Validation.Food.MinPrice, Validation.Food.MaxPrice)]
        public decimal Price { get; set; }

        public string Image { get; set; }

        public int FoodBrandId { get; set; }

        public FoodBrand FoodBrand { get; set; }
    }
}
