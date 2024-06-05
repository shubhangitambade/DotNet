using MVC_DBContext_Customer.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data;
namespace MVC_DBContext_Customer.DBContext
{
    public class EmployeeDBContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public string conString = @"server=localhost;port=3306;user=root;password=password;database=mysqltutorial;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(conString);
        }
    }
}
