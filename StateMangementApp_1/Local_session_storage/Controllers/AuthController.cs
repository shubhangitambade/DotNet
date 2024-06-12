using Microsoft.AspNetCore.Mvc;
using Local_session_storage.Models;

//using System.Security.Claims;

namespace Local_session_storage.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            Claim theClaim = new Claim()
            {
                Email = "",
                Password = ""
            };//property Intialization

            return View(theClaim);
        }

        [HttpPost]
        public IActionResult Login(Claim theClaim)
        {
            
            if(theClaim.Email == "shubhangi.tambade@gmail.com" && theClaim.Password == "seed")
            {
                return RedirectToAction("index", "customer");
            }
            return View(theClaim);
        }
    }
}
