namespace PetFoodShop.Foods.Domain.Categories.Models
{
    using System.Collections.Generic;
    using PetFoodShop.Domain.Models;

    public class FoodCategory : Entity<int>, IAggregateRoot
    {
        private readonly List<FoodBrand> brands;

        internal FoodCategory(string name)
        {
            this.Name = name;
            this.brands = new List<FoodBrand>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<FoodBrand> Brands => this.brands.AsReadOnly();

        public FoodCategory AddBrand(string brand)
        {
            this.brands.Add(new FoodBrand(brand));
            return this;
        }
    }
}
