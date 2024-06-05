
using Singleton_Customer_MVC.Models;

namespace Singleton_Customer_MVC.Service
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Remove(int id);
        void Insert(Customer product);
        void Update(Customer product);
    }
}
