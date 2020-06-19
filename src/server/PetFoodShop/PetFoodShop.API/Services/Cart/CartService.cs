﻿namespace PetFoodShop.API.Services.Cart
{
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.API.Data;
    using PetFoodShop.API.Data.Models;
    using PetFoodShop.API.Services.Common;
    using PetFoodShop.API.Services.Exceptions;
    using PetFoodShop.API.Services.Models.Cart;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly PetFoodDbContext dbContext;
        private readonly IRandomizer randomizer;

        public CartService(PetFoodDbContext dbContext, IRandomizer randomizer)
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
