namespace PetFoodShop.Foods.Domain.Foods.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Categories.Models;
    using PetFoodShop.Domain.Models;

    public class Food : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<FoodCategory> AllowedCategories
            = new FoodCategoryData().GetData().Cast<FoodCategory>();

        internal Food(
            string name, 
            string description,
            int quantity, 
            decimal price, 
            string image,
            int foodBrandId,
            int foodCategoryId)
        {
            // TODO Validate

            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.Price = price;
            this.Image = image;
            this.BrandId = foodBrandId;
            this.CategoryId = foodCategoryId;
        }

        private Food(
            string name,
            string description,
            int quantity,
            decimal price,
            string image)
        {
            // TODO Validate

            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.Price = price;
            this.Image = image;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public string Image { get; private set; }

        public  int BrandId { get; private set; }

        public int CategoryId { get; private set; }

        public Food UpdatePrice(decimal price)
        {
            // validate
            this.Price = price;
            return this;
        }
    }
}
