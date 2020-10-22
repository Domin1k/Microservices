namespace PetFoodShop.Cart.Infrastructure.Persistence
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Infrastructure;

    internal interface ICartDbContext : IDbContext
    {
        DbSet<Shipment> Shipments { get; }
    }
}