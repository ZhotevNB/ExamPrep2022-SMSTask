using System.Collections.Generic;

namespace SMS.Models
{
    public class HomeViewModel
    {
        public string Username { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }=new List<ProductViewModel>();
    }
}
