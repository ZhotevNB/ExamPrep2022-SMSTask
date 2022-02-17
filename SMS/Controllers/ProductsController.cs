using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Contracts;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            productService= _productService;
        }
       
        public HttpResponse Create()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }
            return View();
        }
        [HttpPost]
        [Authorize]
        public HttpResponse Create(ProductAddViewModel model)
        {
          var(isAddedProduct,error) = productService.AddProduct(model);

            if (!isAddedProduct)
            {
                return Error(error);
            }
            return Redirect("/");
        }
    }
}
