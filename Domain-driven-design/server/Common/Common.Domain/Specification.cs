namespace PetFoodShop.Domain
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public abstract class Specification<TDomainModel>
    {
        private static readonly ConcurrentDictionary<string, Func<TDomainModel, bool>> DelegateCache
            = new ConcurrentDictionary<string, Func<TDomainModel, bool>>();

        private readonly List<string> cacheKey;

        protected Specification()
            => this.cacheKey = new List<string> { this.GetType().Name };

        protected virtual bool Include => true;

        public virtual bool IsSatisfiedBy(TDomainModel value)
        {
            if (!this.Include)
            {
                return true;
            }

            var func = DelegateCache.GetOrAdd(
                string.Join(string.Empty, this.cacheKey),
                _ => this.ToExpression().Compile());

            return func(value);
        }

        public Specification<TDomainModel> And(Specification<TDomainModel> specification)
        {
            if (!specification.Include)
            {
                return this;
            }

            this.cacheKey.Add($"{nameof(this.And)}{specification.GetType()}");

            return new BinarySpecification(this, specification, true);
        }

        public Specification<TDomainModel> Or(Specification<TDomainModel> specification)
        {
            if (!specification.Include)
            {
                return this;
            }

            this.cacheKey.Add($"{nameof(this.Or)}{specification.GetType()}");

            return new BinarySpecification(this, specification, false);
        }

        public abstract Expression<Func<TDomainModel, bool>> ToExpression();

        public static implicit operator Expression<Func<TDomainModel, bool>>(Specification<TDomainModel> specification)
            => specification.Include
                ? specification.ToExpression()
                : value => true;

        private class BinarySpecification : Specification<TDomainModel>
        {
            private readonly Specification<TDomainModel> left;
            private readonly Specification<TDomainModel> right;
            private readonly bool andOperator;

            public BinarySpecification(Specification<TDomainModel> left, Specification<TDomainModel> right, bool andOperator)
            {
                this.right = right;
                this.left = left;
                this.andOperator = andOperator;
            }

            public override Expression<Func<TDomainModel, bool>> ToExpression()
            {
                Expression<Func<TDomainModel, bool>> leftExpression = this.left;
                Expression<Func<TDomainModel, bool>> rightExpression = this.right;

                Expression body = this.andOperator
                    ? Expression.AndAlso(leftExpression.Body, rightExpression.Body)
                    : Expression.OrElse(leftExpression.Body, rightExpression.Body);

                var parameter = Expression.Parameter(typeof(TDomainModel));
                body = (BinaryExpression)new ParameterReplacer(parameter).Visit(body);

                body = body ?? throw new InvalidOperationException("Binary expression cannot be null.");

                return Expression.Lambda<Func<TDomainModel, bool>>(body, parameter);
            }
        }

        private class ParameterReplacer : ExpressionVisitor
        {

            private readonly ParameterExpression parameter;

            protected override Expression VisitParameter(ParameterExpression node)
                => base.VisitParameter(this.parameter);

            internal ParameterReplacer(ParameterExpression parameter)
                => this.parameter = parameter;
        }
    }
}
