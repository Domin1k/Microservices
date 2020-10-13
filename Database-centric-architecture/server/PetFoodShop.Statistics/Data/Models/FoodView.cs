namespace PetFoodShop.Statistics.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FoodView
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int FoodId { get; set; }
    }
}
