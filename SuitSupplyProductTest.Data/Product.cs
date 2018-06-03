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

        [Range(0, 999, ErrorMessage = "Price must be between 0 and 999")]
        public decimal Price { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}