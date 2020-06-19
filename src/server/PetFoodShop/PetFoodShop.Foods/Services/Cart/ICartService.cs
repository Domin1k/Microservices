namespace PetFoodShop.Foods.Services.Cart
{
    using PetFoodShop.Foods.Services.Models.Cart;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task CheckoutCartAsync(string customerId, CartModel cart);
    }
}
