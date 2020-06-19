namespace PetFoodShop.API.Services.Common
{
    using System;

    public class Randomizer : IRandomizer
    {
        public long RandomNumber()
        {
            TimeSpan epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
            TimeSpan unixTicks = new TimeSpan(DateTime.UtcNow.Ticks) - epochTicks;
            return unixTicks.Ticks;
        }
    }
}
