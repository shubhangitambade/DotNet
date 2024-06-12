using Microsoft.AspNetCore.Mvc;

namespace Views_Partial.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Linechart()
        {
            return View();
        }

        public IActionResult Barchart()
        {
            return View();
        }

        public IActionResult Piechart()
        {
            return View();
        }
    }
}
