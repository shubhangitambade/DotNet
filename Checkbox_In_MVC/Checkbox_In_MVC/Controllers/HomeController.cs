using Checkbox_In_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Checkbox_In_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Banana" as string, Value = "1",Selected=false });
            items.Add(new SelectListItem { Text = "Apple" as string, Value = "2" ,Selected = false });
            
            items.Add(new SelectListItem { Text = "Graps" as string, Value = "3",Selected = false });
            

            return View(items);
        }
        [HttpPost]
        public ActionResult Index(List<SelectListItem> items)
        {
            ViewBag.Message = "Selected Items:\\n";
            foreach (SelectListItem item in items)
            {
                if (item.Selected)
                {
                    ViewBag.Message += string.Format("{0}\\n", item.Text);
                }
            }
            return View(items);
        }

    }
}
