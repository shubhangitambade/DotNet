using Charts_In_MVC.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Charts_In_MVC.Controllers
{
	public class BarChartController : Controller
	{
		public IActionResult Index()
		{
			var cityPopulation = CityPopulationDAL.GetCityPopulationList();	

			ViewBag.CityPopulation = cityPopulation;

			return View();
		}
	}
}
