namespace PetFoodShop.Foods.Infrastructure.Foods.Configuration
{
    using Domain.Foods;
    using Domain.Foods.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFoodShop.Domain.Models;

    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseHiLo();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ModelConstants.Common.MaxNameLength);

            builder
                .Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(FoodsConstants.Food.MaxDescriptionLength);
        }
    }
}
