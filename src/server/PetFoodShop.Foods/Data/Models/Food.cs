namespace PetFoodShop.Foods.Data.Models
{
    using PetFoodShop.Data;
    using System.ComponentModel.DataAnnotations;

    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(CommonValidation.Common.MinNameLength)]
        [MaxLength(CommonValidation.Common.MaxNameLength)]
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
