using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_DBContext_Customer.DBContext;
using MVC_DBContext_Customer.Models;
using MVC_DBContext_Customer.Repository;

namespace MVC_DBContext_Customer.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            using (EmployeeDBContext _context = new EmployeeDBContext())
            {
                EmployeeRepository repo = new EmployeeRepository(_context);
                List<Employee> employees = repo.GetAll();
                ViewData["allEmployees"] = employees;
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            using (EmployeeDBContext _context = new EmployeeDBContext())
            {
                EmployeeRepository repo = new EmployeeRepository(_context);
                List<Employee> employees = repo.GetAll();
                Employee emp = employees.Find(x => x.Id == id);
               
                ViewData["SingleEmployee"] = emp;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            Console.WriteLine(employee.FName);
            using(EmployeeDBContext _context = new EmployeeDBContext())
            {
                EmployeeRepository repo = new EmployeeRepository(_context);
                bool status = repo.Insert(employee);

                Console.WriteLine(status);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (EmployeeDBContext _context = new EmployeeDBContext())
            {
                EmployeeRepository repo = new EmployeeRepository(_context);

                
                Employee employee = repo.Details(id);
                return View(employee);

                
            }
            //return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
           Console.WriteLine($"{employee.FName}");
            using (EmployeeDBContext _context = new EmployeeDBContext())
            {
                EmployeeRepository repo = new EmployeeRepository(_context);
                bool status = repo.Update(employee);

                Console.WriteLine(status);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            using (EmployeeDBContext _context = new EmployeeDBContext())
            {
                EmployeeRepository repo = new EmployeeRepository(_context);
                bool status = repo.Remove(id);
 
            }
            return RedirectToAction("Index");
        }


    }
}
