namespace PetFoodShop.Statistics.Infrastructure.Configuration
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class FoodViewConfiguration : IEntityTypeConfiguration<FoodView>
    {
        public void Configure(EntityTypeBuilder<FoodView> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.UserId)
                .IsRequired();
        }
    }
}
