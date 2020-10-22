namespace PetFoodShop.Foods.Domain.Foods.Factories
{
    using Models;

    internal class FoodFactory : IFoodFactory
    {
        private string name;
        private string description;
        private string image;
        private int quantity;
        private int brand;
        private int category;
        private decimal price;

        public Food Build()
            => new Food(
                this.name,
                this.description,
                this.quantity,
                this.price,
                this.image,
                this.brand,
                this.category);

        public IFoodFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public IFoodFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IFoodFactory WithImage(string imageUrl)
        {
            this.image = imageUrl;
            return this;
        }

        public IFoodFactory WithQuantity(int quantity)
        {
            this.quantity = quantity;
            return this;
        }

        public IFoodFactory WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public IFoodFactory WithBrand(int brandId)
        {
            this.brand = brandId;
            return this;
        }

        public IFoodFactory WithCategoryId(int categoryId)
        {
            this.category = categoryId;
            return this;
        }
    }
}