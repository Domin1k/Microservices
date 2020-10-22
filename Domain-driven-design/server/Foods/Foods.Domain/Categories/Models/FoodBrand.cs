namespace PetFoodShop.Foods.Domain.Categories.Models
{
    using PetFoodShop.Domain.Models;

    public class FoodBrand : Entity<int>
    {
        internal FoodBrand(string name) => this.Name = name;

        public string Name { get; private set; }
    }
}
