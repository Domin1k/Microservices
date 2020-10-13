namespace PetFoodShop.Cart.Services.Models
{
    using System;

    public class CartOutputModel
    {
        public CartOutputModel(int uniqueNumber, string description, string address, DateTime shippmentDate, DateTime expectedDeliveryDate)
        {
            UniqueNumber = uniqueNumber;
            Description = description;
            Address = address;
            ShippmentDate = shippmentDate;
            ExpectedDeliveryDate = expectedDeliveryDate;
        }

        public string Description { get; }

        public string Address { get; }

        public DateTime ShippmentDate { get; }

        public DateTime ExpectedDeliveryDate { get; }

        public int UniqueNumber { get; }
    }
}
