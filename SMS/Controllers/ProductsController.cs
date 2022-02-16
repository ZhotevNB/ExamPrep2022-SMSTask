using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        public HttpResponse Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }
            return View();
        }
        public HttpResponse Create()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }
            return View();
        }
    }
}
