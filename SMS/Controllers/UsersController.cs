using MyWebServer.Controllers;
using MyWebServer.Http;
using Sms.Data.Common;
using SMS.Contracts;
using SMS.Models;
using SMS.Services;
using MyWebServer.Http.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(
            IUserService _userService
            )
        {
            userService = _userService;
        }

        public HttpResponse Login()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {


            string id = userService.Login(model);

            if (id == null)
            {
                return View();
            }
            else
            {
                this.SignIn(id);
                return Redirect("/");
            }
        }
        public HttpResponse Register()
        {
            return View("Users/Register");
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormModel model)
        {
            var (isRegistered, error) = userService.Register(model);

            if (isRegistered)
            {
                return Redirect("/Users/Login");
            }

            var errorList = error.
                Split(", ")
                .ToList();
            return View(errorList, "/Error");
        }
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
