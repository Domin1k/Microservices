namespace Admin.Startup.Features.Foods.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EditPriceCommand
    {
        public EditPriceCommand()
        {
        }

        public EditPriceCommand(int foodId, decimal price)
        {
            this.FoodId = foodId;
            this.Price = price;
        }

        public int FoodId { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
