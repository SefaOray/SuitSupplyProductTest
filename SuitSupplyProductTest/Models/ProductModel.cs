using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuitSupplyProductTest.Models
{
    public class ProductModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string Photo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be higher than 0")]
        public decimal Price { get; set; }
    }
}
