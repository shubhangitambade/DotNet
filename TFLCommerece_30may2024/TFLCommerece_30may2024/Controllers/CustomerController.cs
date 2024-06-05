using Microsoft.AspNetCore.Mvc;
using TFLCommerece_30may2024.Models;
using TFLCommerece_30may2024.Repository;

namespace TFLCommerece_30may2024.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepo repo = new CustomerRepo();
        public IActionResult Index()
        {

            List<Customer> customerslist = repo.GetAll();

            ViewData["allcustomers"] = customerslist;
            return View();
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Customer customer)
        {
            List<Customer> customers = repo.GetAll();
            customers.Add(customer);

            return RedirectToAction("Index");
        }
        /*public IActionResult details(int id)
        {
            Customer customer = repo.GetById(id);

            ViewData["singleCustomer"] = customer;

            return View();
        }*/


        public IActionResult details2(int id)
        {

            List<Customer> customerslist = repo.GetAll();
            Customer customer = customerslist.Find(x => x.Id == id);

            ViewData["singleCustomer"] = customer;

            return View();
        }
        public IActionResult Remove(int id)
        {
            List<Customer> customerslist = repo.GetAll();
            Customer customer = customerslist.Find(x => x.Id == id);

            customerslist.Remove(customer);

            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(Customer customer)
        {

            List<Customer> customerslist = repo.GetAll();
            Customer existingCustomer = customerslist.FirstOrDefault(customer => customer.Id == customer.Id);
            if(existingCustomer != null)
            {
                customerslist[customerslist.IndexOf(existingCustomer)] = customer;
            }
            //customerslist


            return View();
        }
    }
}
