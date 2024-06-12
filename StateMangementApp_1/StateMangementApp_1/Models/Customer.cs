using Microsoft.AspNetCore.Mvc.Rendering;

namespace StateMangementApp_1.Models
{
    public class Customer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> OrgList { get; set; }
    }
}
