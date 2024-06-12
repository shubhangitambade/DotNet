using Microsoft.AspNetCore.Mvc;

namespace Local_session_storage.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Client Side State Management using LocalStorage, SessionStorage
        public IActionResult LocalStorage()
        {
            return View();
        }
        public IActionResult SessionStorage()
        {
            return View();
        }
    }
}
