using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        [MaxLength(DataConstants.GuidMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DataConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        [Range((double)DataConstants.ProductPriceMinValue,(double)DataConstants.ProductPriceMaxValue)]
        public decimal Price { get; set; }

        public Cart Card { get; set; } 
    }
}
