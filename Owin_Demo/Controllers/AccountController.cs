using Owin_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Owin_Demo.Controllers
{
    public class AccountController : Controller
    {
        List<User> db = new List<User>();
        
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            LoginViewModel login = new LoginViewModel();
            login.RecentUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            db.Add(new User
            {
                UserId = 1,
                Username = "@saeed.balkani",
                Email = "test@yahoo.com",
                Password = "908070"
            });

            if (ModelState.IsValid)
            {
                if (db.Any(a=>a.Email == model.Email && a.Password == model.Password))
                {
                    var identity = new ClaimsIdentity(new[] 
                    {
                        new Claim(ClaimTypes.Email, model.Email)
                    }, "ApplicationCookie");

                    var context = Request.GetOwinContext();
                    var authManager = context.Authentication;
                    authManager.SignIn(identity);
                    return Redirect(model.RecentUrl);
                }
            }
            return View();
        }
    }
}