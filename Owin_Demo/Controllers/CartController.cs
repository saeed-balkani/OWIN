using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Owin_Demo.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}