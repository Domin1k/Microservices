﻿namespace PetFoodShop.Foods.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Persistence;
    using Domain.Categories.Models;
    using Domain.Foods.Models;
    using Microsoft.EntityFrameworkCore;
    using PetFoodShop.Domain;
    using PetFoodShop.Infrastructure;

    public class FoodsDatabaseInitializer : DatabaseInitializer<FoodDbContext>
    {
        public FoodsDatabaseInitializer(FoodDbContext db, IEnumerable<IInitialData> initialDataProviders)
            : base(db, initialDataProviders)
        {
        }

        protected override DbSet<TEntity> GetSet<TEntity>()
            => this.Db.Set<TEntity>();

        public override void Initialize()
        {
            if (this.Db.FoodCategories.Any())
            {
                return;
            }
            var brandsInitializer = this.InitialDataProviders
                .FirstOrDefault(x => x is FoodBrandData)
                ?.GetData()
                .Cast<FoodBrand>()
                .ToList();
            var categoriesInitializer = this.InitialDataProviders.FirstOrDefault(x => x is FoodCategoryData)
                ?.GetData()
                .Cast<FoodCategory>()
                .ToList();
            var foodsInitializer = this.InitialDataProviders.FirstOrDefault(x => x is FoodData)
                ?.GetData()
                .Cast<Food>()
                .ToList();
            if (categoriesInitializer == null || brandsInitializer == null || foodsInitializer == null)
            {
                return;
            }
            foreach (var entity in categoriesInitializer)
            {
                entity.AddBrand(brandsInitializer.OrderByDescending(x => Guid.NewGuid()).FirstOrDefault()?.Name);
                this.Db.FoodCategories.Add(entity);
            }
            this.Db.SaveChanges();
            var cat = this.Db.FoodCategories.First(x => x.Name == FoodCategoryData.DogCategory);
            var brand = this.Db.FoodBrands.First(x => x.Name == FoodBrandData.RoyalCaninBrandName);
            foreach (var entity in foodsInitializer)
            {
                entity
                    .UpdateBrand(brand.Id)
                    .UpdateCategory(cat.Id);
                this.Db.Foods.Add(entity);
            }

            this.Db.SaveChanges();
        }
    }
}
