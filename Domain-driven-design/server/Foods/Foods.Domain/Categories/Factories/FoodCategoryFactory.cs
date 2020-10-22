namespace PetFoodShop.Foods.Domain.Categories.Factories
{
    using Models;

    public class FoodCategoryFactory : IFoodCategoryFactory
    {
        private string name;

        public FoodCategory Build() => new FoodCategory(this.name);

        public IFoodCategoryFactory WithName(string categoryName)
        {
            this.name = categoryName;
            return this;
        }
    }
}
