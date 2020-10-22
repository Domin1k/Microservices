namespace PetFoodShop.Cart.Infrastructure.Services
{
    using System;
    using Application.Contracts;

    public class Randomizer : IRandomizer
    {
        public long RandomNumber()
        {
            var epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
            var unixTicks = new TimeSpan(DateTime.UtcNow.Ticks) - epochTicks;
            return unixTicks.Ticks;
        }
    }
}
