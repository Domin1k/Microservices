namespace PetFoodShop.Foods.Domain.Foods.Factories
{
    using Models;
    using PetFoodShop.Domain.Factories;

    public interface IFoodFactory : IFactory<Food>
    {
        IFoodFactory WithName(string name);

        IFoodFactory WithDescription(string description);

        IFoodFactory WithImage(string imageUrl);

        IFoodFactory WithQuantity(int quantity);

        IFoodFactory WithPrice(decimal price);

        IFoodFactory WithBrand(int brandId);

        IFoodFactory WithCategoryId(int categoryId);
    }
}
