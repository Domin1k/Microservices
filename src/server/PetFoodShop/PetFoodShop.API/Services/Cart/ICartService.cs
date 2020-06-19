namespace PetFoodShop.API.Services.Cart
{
    using PetFoodShop.API.Services.Models.Cart;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task CheckoutCartAsync(string customerId, CartModel cart);
    }
}
