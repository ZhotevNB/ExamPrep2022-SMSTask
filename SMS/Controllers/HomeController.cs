namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Contracts;
    using SMS.Models;
    using SMS.Services;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProductService productService;

        public HomeController(IUserService _userService,
          IProductService _productService)
        {
            userService = _userService;
            productService = _productService;
        }
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                string username = userService.GetUsername(User.Id);

                HomeViewModel model = new HomeViewModel()
                {
                    Username = username,
                    Products = productService.GetProducts()
                };


                return View(model, "/Home/IndexLoggedIn");
            }
            return this.View();
        }




    }
}