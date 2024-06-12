using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StateMangementApp_1.Models;
using System.Diagnostics;
namespace StateMangementApp_1.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {

            Customer newCustomer = new Customer();
            newCustomer.OrgList = PopulateOrgs();
            return View(newCustomer);
            
        }

        [HttpPost]
        public ActionResult Register(Customer customer, string[] organizations)
        {

            customer.OrgList = PopulateOrgs();
            foreach (SelectListItem item in customer.OrgList)
            {
                if (item != null)
                {
                    if (organizations.Contains(item.Value))
                    {
                        item.Selected = true;
                    }
                }
            }
            return View();
        }

        public static List<SelectListItem> PopulateOrgs()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "CDAC", Value = "CDAC", Selected = false });
            items.Add(new SelectListItem { Text = "IBM", Value = "IBM", Selected = false });
            items.Add(new SelectListItem { Text = "SEED", Value = "SEED", Selected = false });
            items.Add(new SelectListItem { Text = "Microsoft", Value = "Microsoft", Selected = false });
            items.Add(new SelectListItem { Text = "Google", Value = "Google", Selected = false });
            return items;
        }
    }
}
