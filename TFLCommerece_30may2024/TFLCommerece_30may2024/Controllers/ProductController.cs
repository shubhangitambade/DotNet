using Microsoft.AspNetCore.Mvc;

namespace TFLCommerece_30may2024.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
