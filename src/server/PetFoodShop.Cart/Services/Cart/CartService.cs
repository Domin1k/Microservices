namespace PetFoodShop.Cart.Services
{
    using PetFoodShop.Cart.Data;
    using PetFoodShop.Cart.Data.Models;
    using PetFoodShop.Cart.Infrastructure.Exceptions;
    using PetFoodShop.Cart.Services.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly CartDbContext dbContext;
        private readonly IRandomizer randomizer;

        public CartService(CartDbContext dbContext, IRandomizer randomizer)
        {
            this.dbContext = dbContext;
            this.randomizer = randomizer;
        }

        public async Task<CartOutputModel> CheckoutCartAsync(string customerId, CartModel cart)
        {
            if (cart?.Items == null || !cart.Items.Any())
            {
                throw new CheckoutFailedException($"Cannot send shippment for empty cart");
            }
            if (cart.DeliveryAddress == null)
            {
                throw new CheckoutFailedException($"Customer address is null");
            }

            var shippment = new Shippment
            {
                CustomerId = customerId,
                Description = GetDescriptionFromCart(cart),
                UniqueNumber = (int)this.randomizer.RandomNumber(),
                ShippmentDate = DateTime.UtcNow,
                ExpectedDeliveryDate = DateTime.UtcNow.AddDays(3),
                Address = cart.DeliveryAddress
            };
            this.dbContext.Shippments.Add(shippment);

            await this.dbContext.SaveChangesAsync();

            return new CartOutputModel(shippment.UniqueNumber, shippment.Description, shippment.Address, shippment.ShippmentDate, shippment.ExpectedDeliveryDate);
        }

        private string GetDescriptionFromCart(CartModel cart)
            => string.Join(", ", cart.Items.Select(x => $"Ordered {x.Name} | Price {x.Price} | Quantity - {x.Quantity}"));
    }
}
