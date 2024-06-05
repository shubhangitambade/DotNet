using Singleton_Customer_MVC.Models;

namespace Singleton_Customer_MVC.Service
{
    
    public class CustomerService: ICustomerService
    {
        List<Customer> customers = new List<Customer>();
        public CustomerService() {

            //customers = new List<Customer>();
            customers.Add(new Customer { Id = 23, Name = "Ajay Mane", Email = "ajay@gmail.com", Phone = "982345679" });
            customers.Add(new Customer { Id = 24, Name = "Nishikant Kamat", Email = "nkamat@gmail.com", Phone = "9180234567" });
            customers.Add(new Customer { Id = 25, Name = "Rupali Barve", Email = "rbarve@gmail.com", Phone = "817234567" });
            customers.Add(new Customer { Id = 26, Name = "Sadhana ", Email = "sadhana@gmail.com", Phone = "712345679" });


        }

        public List<Customer> GetAll()
        {
            return customers;
        }

        public Customer GetById(int id)
        {
            Customer customer = customers.Find(x => x.Id == id);
            return customer;
        }

        public void Insert(Customer customer)
        {
            customers.Add(customer);
        }

        public void Remove(int id)
        {
            Customer customer = customers.Find(x => x.Id == id);
            customers.Remove(customer);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(p => p.Id == customer.Id);
            if (existingCustomer != null)
            {
                customers[customers.IndexOf(existingCustomer)] = customer;
            }
        }
    }
}
