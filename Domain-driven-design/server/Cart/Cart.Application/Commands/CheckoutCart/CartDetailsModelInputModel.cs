﻿namespace PetFoodShop.Cart.Application.Commands.CheckoutCart
{
    public class CartDetailsModelInputModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public decimal Price { get; set; }
    }
}
