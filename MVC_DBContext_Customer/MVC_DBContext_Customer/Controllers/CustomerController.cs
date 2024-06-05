using Microsoft.AspNetCore.Mvc;
using MVC_DBContext_Customer.Repository;
using MVC_DBContext_Customer.Models;


namespace MVC_DBContext_Customer.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController() { }
        public IActionResult Index()
        {

            CustomerRepository repository = new CustomerRepository();
            List<Customer> customerList = repository.GetAll();
            ViewData["allCustomers"] = customerList;
            return View();
        }

        public IActionResult Details(int id)
        {
            CustomerRepository repository = new CustomerRepository();
            List<Customer> customerList = repository.GetAll();
            Customer customer = customerList.Find(x => x.Id == id);
            ViewData["singleCustomer"] = customer;
            return View();
        }

        public IActionResult Remove(int id)
        {
            CustomerRepository repository = new CustomerRepository();
            List<Customer> customerList = repository.GetAll();
            Customer customer = customerList.Find(x => x.Id == id);
           
            customerList.Remove(customer);
            return RedirectToAction("Index");
        }

       
    }
}
