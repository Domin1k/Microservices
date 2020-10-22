namespace PetFoodShop.Cart.Domain.Factories
{
    using System;
    using Models;

    public class ShipmentFactory : IShipmentFactory
    {
        private int uniqueNumber;
        private string description;
        private string address;
        private DateTime shipmentDate;
        private DateTime expectedDeliveryDate;
        private string customerId;

        public Shipment Build()
        {
            if (this.expectedDeliveryDate < DateTime.UtcNow || this.shipmentDate < DateTime.UtcNow)
            {
                // TODO throw
            }

            if (this.expectedDeliveryDate < this.shipmentDate)
            {
                // TODO throw
            }
            return new Shipment(
                this.uniqueNumber,
                this.description,
                this.address,
                this.shipmentDate,
                this.expectedDeliveryDate,
                this.customerId);
        }

        public IShipmentFactory WithUniqueNumber(int uniqueNumber)
        {
            this.uniqueNumber = uniqueNumber;
            return this;
        }

        public IShipmentFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IShipmentFactory WithAddress(string address)
        {
            this.address = address;
            return this;
        }

        public IShipmentFactory WithShipmentDate(DateTime shipmentDate)
        {
            this.shipmentDate = shipmentDate;
            return this;
        }

        public IShipmentFactory WithExpectedDeliveryDate(DateTime expectedDeliveryDate)
        {
            this.expectedDeliveryDate = expectedDeliveryDate;
            return this;
        }

        public IShipmentFactory WithCustomerId(string customerId)
        {
            this.customerId = customerId;
            return this;
        }
    }
}
