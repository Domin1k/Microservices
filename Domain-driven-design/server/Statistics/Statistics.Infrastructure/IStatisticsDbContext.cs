namespace PetFoodShop.Statistics.Infrastructure
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure;

    internal interface IStatisticsDbContext : IDbContext
    {
        DbSet<FoodView> FoodViews { get; }

        DbSet<Statistics> Statistics { get; }
    }
}
