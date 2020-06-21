namespace PetFoodShop.Statistics.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Statistics
    {
        [Key]
        public int Id { get; set; }

        public int TotalFoods { get; set; }

        public int TotalFoodBrands { get; set; }
    }
}
