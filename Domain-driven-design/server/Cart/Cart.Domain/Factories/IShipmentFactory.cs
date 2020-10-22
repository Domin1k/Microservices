namespace PetFoodShop.Cart.Domain.Factories
{
    using System;
    using Models;
    using PetFoodShop.Domain.Factories;

    public interface IShipmentFactory : IFactory<Shipment>
    {
        IShipmentFactory WithUniqueNumber(int uniqueNumber);

        IShipmentFactory WithDescription(string description);

        IShipmentFactory WithAddress(string address);

        IShipmentFactory WithShipmentDate(DateTime shipmentDate);

        IShipmentFactory WithExpectedDeliveryDate(DateTime expectedDeliveryDate);

        IShipmentFactory WithCustomerId(string customerId);
    }
}