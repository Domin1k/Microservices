namespace PetFoodShop.Foods.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Shippment
    {
        [Key]
        public int Id { get; set; }

        public int UniqueNumber { get; set; }

        [MinLength(Validation.Shippment.MinDescriptionLength)]
        [MaxLength(Validation.Shippment.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(Validation.Shippment.MinAddressLength)]
        [MaxLength(Validation.Shippment.MaxAddressLength)]
        public string Address { get; set; }

        public DateTime ShippmentDate { get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }

        [Required]
        public string CustomerId { get; set; }
    }
}
