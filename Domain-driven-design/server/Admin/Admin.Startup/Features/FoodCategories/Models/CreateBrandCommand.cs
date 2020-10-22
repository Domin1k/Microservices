namespace Admin.Startup.Features.FoodCategories.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateBrandCommand
    {
        [Required]
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
    }
}
