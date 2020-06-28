namespace PetFoodShop.Cart.Services.Models
{
    using System;

    public class CartOutputModel
    {
        public CartOutputModel(string description, string address, DateTime shippmentDate, DateTime expectedDeliveryDate)
        {
            Description = description;
            Address = address;
            ShippmentDate = shippmentDate;
            ExpectedDeliveryDate = expectedDeliveryDate;
        }

        public string Description { get; }

        public string Address { get; }

        public DateTime ShippmentDate { get; }

        public DateTime ExpectedDeliveryDate { get; }
    }
}
