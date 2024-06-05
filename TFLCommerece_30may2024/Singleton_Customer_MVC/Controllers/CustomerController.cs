using Microsoft.AspNetCore.Mvc;
using Singleton_Customer_MVC.Service;
using Singleton_Customer_MVC.Models;

namespace Singleton_Customer_MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService service)
        {
            _customerService = service;  //DI
        }
        //CRUD Operation Action Methods
        public IActionResult Index()
        {
            List<Customer> customers = _customerService.GetAll();
            ViewData["customerList"] = customers;
            return View();
        }
        public IActionResult Details(int id)
        {
            Customer customer = _customerService.GetById(id);
            ViewData["singleCustomer"] = customer;
            return View();
        }
        public IActionResult Remove(int id)
        {
            _customerService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Customer theProduct = _customerService.GetById(id);
            return View(theProduct);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Customer customer)
        {
            _customerService.Insert(customer);
            return RedirectToAction("Index");
        }
    }
}
