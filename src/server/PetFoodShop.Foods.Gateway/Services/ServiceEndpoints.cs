﻿namespace PetFoodShop.Foods.Gateway.Services
{
    using System;
    using System.Linq;

    public class ServiceEndpoints
    {
        public string Foods { get; private set; }

        public string Statistics { get; private set; }

        public string this[string service]
            => this.GetType()
                .GetProperties()
                .Where(pr => string
                    .Equals(pr.Name, service, StringComparison.CurrentCultureIgnoreCase))
                .Select(pr => (string)pr.GetValue(this))
                .FirstOrDefault()
                ?? throw new InvalidOperationException($"External service with name '{service}' does not exists.");
    }
}
