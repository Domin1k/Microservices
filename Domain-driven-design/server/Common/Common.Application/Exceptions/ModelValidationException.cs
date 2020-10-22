namespace PetFoodShop.Application.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation.Results;

    public class ModelValidationException : Exception
    {
        public ModelValidationException()
            : base("One or more validation errors have occurred.")
            => this.Errors = new Dictionary<string, string[]>();

        public ModelValidationException(IEnumerable<ValidationFailure> errors)
            : this()
        {
            this.Errors = errors
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(k => k.Key, v => v.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
