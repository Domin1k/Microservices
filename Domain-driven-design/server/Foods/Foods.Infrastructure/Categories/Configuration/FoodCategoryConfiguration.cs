namespace PetFoodShop.Foods.Infrastructure.Categories.Configuration
{
    using Domain.Categories.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetFoodShop.Domain.Models;

    internal class FoodCategoryConfiguration : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseHiLo();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ModelConstants.Common.MaxNameLength);

            builder
                .HasMany(x => x.Brands)
                .WithOne()
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
