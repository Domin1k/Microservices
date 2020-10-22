namespace PetFoodShop.Foods.Domain.Categories.Factories
{
    using Models;
    using PetFoodShop.Domain.Factories;

    public interface IFoodCategoryFactory : IFactory<FoodCategory>
    {
        IFoodCategoryFactory WithName(string categoryName);
    }
}
