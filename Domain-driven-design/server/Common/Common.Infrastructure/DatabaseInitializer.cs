﻿namespace PetFoodShop.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public abstract class DatabaseInitializer<Context> : IInitializer
        where Context : DbContext
    {
        private readonly Context db;

        protected DatabaseInitializer(Context db, IEnumerable<IInitialData> initialDataProviders)
        {
            this.db = db;
            this.InitialDataProviders = initialDataProviders;
        }

        protected Context Db => this.db;

        protected IEnumerable<IInitialData> InitialDataProviders { get;  }

        public virtual void Initialize()
        {
            foreach (var initialDataProvider in this.InitialDataProviders)
            {
                if (this.DataSetIsEmpty(initialDataProvider.EntityType))
                {
                    var data = initialDataProvider.GetData();

                    foreach (var entity in data)
                    {
                        this.db.Add(entity);
                    }
                }
            }

            this.db.SaveChanges();
        }

        protected bool DataSetIsEmpty(Type type)
        {
            var setMethod = this.GetType()
                    .GetMethod(nameof(this.GetSet), BindingFlags.Instance | BindingFlags.NonPublic)
                    !.MakeGenericMethod(type);

            var set = setMethod.Invoke(this, Array.Empty<object>());

            var countMethod = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
                .MakeGenericMethod(type);

            var result = (int)countMethod.Invoke(null, new[] { set })!;

            return result == 0;
        }

        protected abstract DbSet<TEntity> GetSet<TEntity>()
            where TEntity : class;
    }
}
