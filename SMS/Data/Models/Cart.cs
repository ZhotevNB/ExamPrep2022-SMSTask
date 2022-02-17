using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Cart
    {
        [Key]
        [MaxLength(DataConstants.GuidMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public User User { get; set; }

        [Required]
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
