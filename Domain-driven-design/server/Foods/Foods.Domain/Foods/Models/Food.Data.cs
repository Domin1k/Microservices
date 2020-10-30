namespace PetFoodShop.Foods.Domain.Foods.Models
{
    using System;
    using System.Collections.Generic;
    using PetFoodShop.Domain;

    public class FoodData : IInitialData
    {
        public Type EntityType => typeof(Food);

        public IEnumerable<object> GetData()
            => new List<Food>
            {
                new Food(
                    "Jack Russell Terrier Puppy Dry Dog Food",
                    "Royal Canin Jack Russell Terrier Puppy dry dog food is designed to meet the nutritional needs of a purebred Jack Russell 8 weeks to 10 months old",
                    10,
                    35.99m,
                    "https://images.salsify.com/image/upload/s--0QPiQuk2--/w_500/z8u8irfgrvyo3vtzp2yy.JPG?w=500",
                    0,
                    0),
                new Food(
                    "Beagle Adult Dry Dog Food",
                    "Royal Canin Beagle Adult dry dog food is designed to meet the nutritional needs of purebred Beagles 12 months and older",
                    7,
                    45.99m,
                    "https://images.salsify.com/image/upload/s--FRhYxkBR--/w_500/c2pvgwfas3npj7hs4mfu.JPG?w=500",
                    0,
                    0),
                new Food(
                    "Miniature Schnauzer Puppy Dry Dog Food",
                    "Royal Canin Miniature Schnauzer Puppy dry dog food is designed to meet the nutritional needs of purebred Miniature Schnauzers 8 weeks to 10 months old",
                    1,
                    33.99m,
                    "https://images.salsify.com/image/upload/s--i8iYfhc---/w_500/la7mexvp1gghglnlucdn.JPG?w=500",
                    0,
                    0),
                new Food(
                    "Setter Adult Dry Dog Food",
                    "Royal Canin Setter Adult dry dog food is designed to meet the nutritional needs of purebred Setters 12 months and older",
                    11,
                    65.99m,
                    "https://images.salsify.com/image/upload/s--YsNumWo5--/w_500/tano852zkeoig1ypg1k7.JPG?w=500",
                    0,
                    0),
                new Food(
                    "Cavalier King Charles Adult Dry Dog Food",
                    "Royal Canin Cavalier King Charles Spaniel Adult dry dog food is designed to meet the nutritional needs of purebred Cavaliers 10 months and older",
                    5,
                    23.99m,
                    "https://images.salsify.com/image/upload/s--IptYNmh0--/w_500/hthkzxljyfj8ff5p0kuc.JPG?w=500",
                    0,
                    0),
                new Food(
                    "Cocker Spaniel Adult Dry Dog Food",
                    "Royal Canin Cocker Spaniel Adult dry dog food is designed to meet the nutritional needs of purebred Cocker Spaniels 12 months and older",
                    3,
                    33.99m,
                    "https://images.salsify.com/image/upload/s--0Ti_Wtzn--/w_500/zdz0gytmdiafdj0bj67t.JPG?w=500",
                    0,
                    0),
            };
    }
}
