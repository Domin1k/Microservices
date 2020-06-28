namespace PetFoodShop.Cart.Services
{
    using PetFoodShop.Cart.Services.Models;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task<CartOutputModel> CheckoutCartAsync(string customerId, CartModel cart);
    }
}
