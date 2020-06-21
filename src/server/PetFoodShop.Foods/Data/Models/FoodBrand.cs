namespace PetFoodShop.Foods.Data.Models
{
    using PetFoodShop.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FoodBrand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(CommonValidation.Common.MinNameLength)]
        [MaxLength(CommonValidation.Common.MaxNameLength)]
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }

        public FoodCategory FoodCategory { get; set; }

        public IEnumerable<Food> Foods { get; set; } = new HashSet<Food>();
    }
}
