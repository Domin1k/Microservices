namespace PetFoodShop.Cart.Application.Commands.CheckoutCart
{
    using System;

    public class CheckoutCartOutputModel
    {
        public CheckoutCartOutputModel(int uniqueNumber, string description, string address, DateTime shipmentDate, DateTime expectedDeliveryDate)
        {
            this.UniqueNumber = uniqueNumber;
            this.Description = description;
            this.Address = address;
            this.ShipmentDate = shipmentDate;
            this.ExpectedDeliveryDate = expectedDeliveryDate;
        }

        public string Description { get; private set; }

        public string Address { get; private set; }

        public DateTime ShipmentDate { get; private set; }

        public DateTime ExpectedDeliveryDate { get; private set; }

        public int UniqueNumber { get; private set; }
    }
}
