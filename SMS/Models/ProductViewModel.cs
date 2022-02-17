using SMS.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace SMS.Models
{
    public class ProductViewModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

        public Cart Card { get; set; } 
    }
}
