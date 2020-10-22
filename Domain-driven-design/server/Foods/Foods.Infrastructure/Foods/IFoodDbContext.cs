namespace PetFoodShop.Foods.Infrastructure.Foods
{
    using Domain.Foods.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure;

    internal interface IFoodDbContext : IDbContext
    {
        DbSet<Food> Foods { get; }
    }
}
