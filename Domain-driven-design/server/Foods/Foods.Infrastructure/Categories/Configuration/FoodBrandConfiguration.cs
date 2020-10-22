namespace PetFoodShop.Foods.Infrastructure.Categories.Configuration
{
    using Domain.Categories.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFoodShop.Domain.Models;

    public class FoodBrandConfiguration : IEntityTypeConfiguration<FoodBrand>
    {
        public void Configure(EntityTypeBuilder<FoodBrand> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ModelConstants.Common.MaxNameLength);
        }
    }
}
