using TFLCommerece_30may2024.Models;

namespace TFLCommerece_30may2024.Repository
{
    public class CustomerRepo
    {
        List<Customer> customers = new List<Customer>();


        public CustomerRepo() {

            customers.Add(new Customer { Id = 23, Name = "Ajay Mane", Email = "ajay@gmail.com", Phone = "982345679" });
            customers.Add(new Customer { Id = 24, Name = "Nishikant Kamat", Email = "nkamat@gmail.com", Phone = "9180234567" });
            customers.Add(new Customer { Id = 25, Name = "Rupali Barve", Email = "rbarve@gmail.com", Phone = "817234567" });
            customers.Add(new Customer { Id = 26, Name = "Sadhana ", Email = "sadhana@gmail.com", Phone = "712345679" });


        }
        public List<Customer> GetAll()
        {
            
            /*customers.Add(new Customer { Id = 23, Name = "Ajay Mane", Email = "ajay@gmail.com", Phone = "982345679" });
            customers.Add(new Customer { Id = 24, Name = "Nishikant Kamat", Email = "nkamat@gmail.com", Phone = "9180234567" });
            customers.Add(new Customer { Id = 25, Name = "Rupali Barve", Email = "rbarve@gmail.com", Phone = "817234567" });
            customers.Add(new Customer { Id = 26, Name = "Sadhana ", Email = "sadhana@gmail.com", Phone = "712345679" });*/

            return customers;
        }

        public Customer GetById(int id)
        {
            Customer customer = customers.Find(x => x.Id == id);

            return customer;
        }
    }
}
