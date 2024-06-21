using Microsoft.AspNetCore.Mvc;
using Charts_In_MVC.DAL;
using Newtonsoft.Json;
namespace Charts_In_MVC.Controllers
{
    public class ColumnChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult PopulationChart()
        {
            var populationList = PopulationDAL.GetCityPopulationList();
            foreach(var population in populationList)
            {
                Console.WriteLine(population.CityName + " " + population.PopulationYear1990);
            }
            //ViewBag.PopulationChart = populationList;

            ViewBag.PopulationChart = JsonConvert.SerializeObject(populationList);


            return View();
        }

        /*[HttpGet]
        public JsonResult PopulationChart()
        {
            var populationList = PopulationDAL.GetCityPopulationList();

            ViewBag.PopulationChart = populationList;
            return Json(populationList);
        }*/
    }
}
