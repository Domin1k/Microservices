namespace PetFoodShop.Cart.Application.Commands.CheckoutCart
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Factories;
    using MediatR;
    using PetFoodShop.Application.Contracts;

    public class CheckoutCartCommand : CheckoutCartCommandInputModel, IRequest<CheckoutCartOutputModel>
    {
        public class CheckoutCartCommandHandler : IRequestHandler<CheckoutCartCommand, CheckoutCartOutputModel>
        {
            private readonly ICartRepository cartRepository;
            private readonly IShipmentFactory shipmentFactory;
            private readonly ICurrentUserService currentUser;
            private readonly IRandomizer randomizer;
            public CheckoutCartCommandHandler(
                ICartRepository cartRepository,
                IShipmentFactory shipmentFactory,
                ICurrentUserService currentUser,
                IRandomizer randomizer)
            {
                this.cartRepository = cartRepository;
                this.shipmentFactory = shipmentFactory;
                this.currentUser = currentUser;
                this.randomizer = randomizer;
            }

            public async Task<CheckoutCartOutputModel> Handle(CheckoutCartCommand request, CancellationToken cancellationToken)
            {
                var shipment = this.shipmentFactory
                    .WithCustomerId(this.currentUser.UserId.ToString())
                    .WithDescription(this.GenerateCartDescription(request))
                    .WithUniqueNumber((int) this.randomizer.RandomNumber())
                    .WithShipmentDate(DateTime.UtcNow)
                    .WithExpectedDeliveryDate(DateTime.UtcNow.AddDays(3))
                    .WithAddress(request.DeliveryAddress)
                    .Build();

                await this.cartRepository.Save(shipment, cancellationToken);

                return new CheckoutCartOutputModel(
                    shipment.UniqueNumber,
                    shipment.Description,
                    shipment.Address,
                    shipment.ShipmentDate,
                    shipment.ExpectedDeliveryDate);
            }

            private string GenerateCartDescription(CheckoutCartCommandInputModel request)
                => string.Join(", ", request.Cart.Select(x => $"Ordered {x.ProductName} | Price {x.Price} | Quantity - {x.ProductQuantity}"));
        }
    }
}
