using Microsoft.EntityFrameworkCore;
using MVC_DBContext_Customer.DBContext;
using MVC_DBContext_Customer.Models;

namespace MVC_DBContext_Customer.Repository
{
    public class EmployeeRepository
    {

        private EmployeeDBContext _context;
        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            var employees = _context.Employee.ToList();
            return employees;
        }
        public Employee Details(int id)
        {
            
            Employee empDetails = _context.Employee.FirstOrDefault(emp => emp.Id == id);
           
                return empDetails;
            
        }
        public bool Remove(int id)
        {
            bool status = false;
            var empToDelete = _context.Employee.FirstOrDefault(emp => emp.Id == id);
            if (empToDelete != null)
            {
                _context.Employee.Remove(empToDelete);
                _context.SaveChanges();
                status = true;
            }  
            return status;
        }

        public bool Insert(Employee emp) {
            bool status = false;
            _context.Employee.Add(emp);
            _context.SaveChanges();
            status = true;
            return status;
        }

        public bool Update(Employee emp)
        {
            bool status = false;
            _context.Employee.Update(emp);
            _context.SaveChanges();
            status = true;
            return status;
        }
    }
}
