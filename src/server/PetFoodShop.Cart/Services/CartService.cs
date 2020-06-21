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

        public async Task CheckoutCartAsync(string customerId, CartModel cart)
        {
            if (cart.DeliveryAddress == null)
            {
                throw new CheckoutFailedException($"Customer address is null");
            }

            var shippments = cart.Items.Select(x => new Shippment
            {
                CustomerId = customerId,
                Description = $"Ordered {x.Name} | Price {x.Price} | Quantity - {x.Quantity}",
                UniqueNumber = (int)this.randomizer.RandomNumber(),
                ShippmentDate = DateTime.UtcNow,
                ExpectedDeliveryDate = DateTime.UtcNow.AddDays(3),
                Address = cart.DeliveryAddress
            });

            this.dbContext.Shippments.AddRange(shippments);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
