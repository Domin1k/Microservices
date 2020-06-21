namespace PetFoodShop.Foods.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FoodCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Validation.Common.MinNameLength)]
        [MaxLength(Validation.Common.MaxNameLength)]
        public string Name { get; set; }

        public IEnumerable<FoodBrand> FoodBrands { get; } = new HashSet<FoodBrand>();
    }
}
