using SMS.Data;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class ProductAddViewModel
    {
        [StringLength(DataConstants.ProductNameMaxLength,MinimumLength =DataConstants.ProductNameMinLength,ErrorMessage ="{0} must be between {2} and {1}")]
        public string Name { get; set; }

        [Range((double)DataConstants.ProductPriceMinValue,(double)DataConstants.ProductPriceMaxValue,ErrorMessage ="{0} must be between {1} and {2}")]
        public decimal Price { get; set; }
    }
}
