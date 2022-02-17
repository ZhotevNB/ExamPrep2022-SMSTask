namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Contracts;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
      
        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                string username = userService.GetUsername(User.Id);


                return View((object)username,"/Home/IndexLoggedIn");
            }
            return this.View();
        }
        
     

       
    }
}