using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tempdata_MVC.Controllers
{
    public class AnotherController : Controller
    {
        // GET: Another
        public ActionResult Index()
        {
            var GetCity = TempData["city"] as String;
            ViewData["Newcity"] = GetCity;
            return View();
        }
    }
}