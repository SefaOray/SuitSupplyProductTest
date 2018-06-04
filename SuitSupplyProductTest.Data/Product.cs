using System;
using System.ComponentModel.DataAnnotations;

namespace SuitSupplyProductTest.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string Photo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be higher than 0")]
        public decimal Price { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}