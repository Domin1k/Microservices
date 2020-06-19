namespace PetFoodShop.API.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FoodBrand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Validation.Common.MinNameLength)]
        [MaxLength(Validation.Common.MaxNameLength)]
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }

        public FoodCategory FoodCategory { get; set; }

        public IEnumerable<Food> Foods { get; set; } = new HashSet<Food>();
    }
}
