using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tempdata_MVC.Models;

namespace Tempdata_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Customer data = new Customer()
            {
                CustomerID = 1,
                CustomerName = "Abcd",
                Country = "PAK"
            };
            TempData["mydata"] = data;
            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewData["customer"] = TempData["mydata"];
            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            TempData["city"] = "Pune";

            return RedirectToAction("Services");
        }

        public ActionResult Services()
        {
            //ViewBag.Message = "Your contact page.";
            var GetCity = TempData["city"] as String;
            ViewData["Newcity"] = GetCity;
            return RedirectToAction("Index","Another");
        }
    }
}