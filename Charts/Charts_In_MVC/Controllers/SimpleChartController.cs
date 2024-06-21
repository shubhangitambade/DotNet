using Microsoft.AspNetCore.Mvc;

namespace Charts_In_MVC.Controllers
{
    public class SimpleChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
