using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(ICartService _cartService)
        {
            cartService = _cartService;
        }
    
        public HttpResponse Add(string productId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }
            var (productIsAddedToCart, error) = cartService.AddProductToCart(productId, User.Id);

            if (!productIsAddedToCart)
            {
                return Error(error);
            }

            return Redirect("/Carts/Details");
        }
        public HttpResponse Details()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }
            var model = cartService.GetAllCartProducts(User.Id);
            return View(model);  
        }
        [Authorize]
        public HttpResponse Buy()
        {
            var(isBoth,error)=cartService.BuyProductFromCart(User.Id);

            if (!isBoth)
            {
                return Error(error);
            }

            return Redirect("/");
        }
      
    }
}
