namespace MVC_DBContext_Customer.Models
{
    public class Customer
    {

        //private static List<Customer> instance = null;
        /*private Customer()
        {
        }*/
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        /*public static List<Customer> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new List<Customer>();
                }
                return instance;
            }
        }*/
    }
}
