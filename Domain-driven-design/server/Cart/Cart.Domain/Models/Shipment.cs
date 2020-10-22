namespace PetFoodShop.Cart.Domain.Models
{
    using PetFoodShop.Domain.Models;
    using System;

    public class Shipment : Entity<int>, IAggregateRoot
    {
        internal Shipment(
            int uniqueNumber,
            string description,
            string address, 
            DateTime shipmentDate,
            DateTime expectedDeliveryDate,
            string customerId)
        {
            // TODO validate
            this.UniqueNumber = uniqueNumber;
            this.Description = description;
            this.Address = address;
            this.ShipmentDate = shipmentDate;
            this.ExpectedDeliveryDate = expectedDeliveryDate;
            this.CustomerId = customerId;
        }

        public int UniqueNumber { get; private set; }

        //[MinLength(Validation.Shipment.MinDescriptionLength)]
        //[MaxLength(Validation.Shipment.MaxDescriptionLength)]
        public string Description { get; private set; }

        //[Required]
        //[MinLength(Validation.Shipment.MinAddressLength)]
        //[MaxLength(Validation.Shipment.MaxAddressLength)]
        public string Address { get; private set; }

        public DateTime ShipmentDate { get; private set; }

        public DateTime ExpectedDeliveryDate { get; private set; }

        //[Required]
        public string CustomerId { get; private set; }
    }
}
