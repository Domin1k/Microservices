namespace PetFoodShop.Statistics.Infrastructure.Configuration
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            const string id = "Id";

            builder
                .Property<int>(id);

            builder
                .HasKey(id);


            builder
                .HasMany(d => d.FoodViews)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("foodsViews");
        }
    }
}
