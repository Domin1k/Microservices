﻿namespace PetFoodShop.Cart.Services.Models
{
    using System.Collections.Generic;

    public class CartModel
    {
        public CartModel(IEnumerable<CartItemModel> items, string deliveryAddress)
        {
            this.Items = items;
            this.DeliveryAddress = deliveryAddress;
        }

        public IEnumerable<CartItemModel> Items { get; }

        public string DeliveryAddress { get;  }
    }
}
