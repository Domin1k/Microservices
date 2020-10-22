namespace PetFoodShop.Cart.Infrastructure.Persistence.Configuration
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Description)
                .HasMaxLength(Validation.ShipmentConstants.MaxDescriptionLength);

            builder
                .Property(x => x.Address)
                .HasMaxLength(Validation.ShipmentConstants.MaxAddressLength)
                .IsRequired();

            builder
                .Property(x => x.CustomerId)
                .IsRequired();
        }
    }
}
