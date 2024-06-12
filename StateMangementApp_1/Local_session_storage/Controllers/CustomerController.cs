using Microsoft.AspNetCore.Mvc;

namespace Local_session_storage.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
