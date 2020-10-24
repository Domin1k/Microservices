//namespace PetFoodShop.Domain.Models
//{
//    using System;
//    using FluentAssertions;
//    using Xunit;

//    public class EntitySpecs
//    {
//        [Fact]
//        public void EntitiesWithEqualIdsShouldBeEqual()
//        {
//            // Arrange
//            var first = new TestItem().SetId(1);
//            var second = new TestItem().SetId(1);

//            // Act
//            var result = first == second;

//            // Arrange
//            result.Should().BeTrue();
//        }

//        [Fact]
//        public void EntitiesWithDifferentIdsShouldNotBeEqual()
//        {
//            // Arrange
//            var first = new TestItem().SetId(1);
//            var second = new TestItem().SetId(2);

//            // Act
//            var result = first == second;

//            // Arrange
//            result.Should().BeFalse();
//        }

//        private class TestItem : Entity<int>
//        {
//            public TestItem()
//            {
//            }
//        }
//    }

//    internal static class EntityExtensions
//    {
//        public static TEntity SetId<TEntity>(this TEntity entity, int id)
//            where TEntity : Entity<int>
//            => (entity.SetId<int>(id) as TEntity)!;

//        public static TEntity SetId<TEntity>(this TEntity entity, Guid id)
//            where TEntity : Entity<Guid>
//            => (entity.SetId<Guid>(id) as TEntity);

//        private static Entity<T> SetId<T>(this Entity<T> entity, int id)
//            where T : struct
//        {
//            entity
//                .GetType()
//                .BaseType!
//                .GetProperty(nameof(Entity<T>.Id))!
//                .GetSetMethod(true)!
//                .Invoke(entity, new object[] { id });

//            return entity;
//        }

//        private static Entity<T> SetId<T>(this Entity<T> entity, Guid id)
//            where T : struct
//        {
//            entity
//                .GetType()
//                .BaseType!
//                .GetProperty(nameof(Entity<T>.Id))!
//                .GetSetMethod(true)!
//                .Invoke(entity, new object[] { id });

//            return entity;
//        }
//    }
//}
