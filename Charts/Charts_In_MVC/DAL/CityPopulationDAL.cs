using Charts_In_MVC.Models;

namespace Charts_In_MVC.DAL
{
	public class CityPopulationDAL
	{

		public static List<CityPopulation> GetCityPopulationList()
		{
			var list = new List<CityPopulation>();
			list.Add(new CityPopulation { CityName = "PURI", PopulationYear2020 = 28000, PopulationYear2010 = 45000, PopulationYear2000 = 22000, PopulationYear1990 = 50000 });
			list.Add(new CityPopulation { CityName = "Bhubaneswar", PopulationYear2020 = 30000, PopulationYear2010 = 49000, PopulationYear2000 = 24000, PopulationYear1990 = 39000 });
			list.Add(new CityPopulation { CityName = "Cuttack", PopulationYear2020 = 35000, PopulationYear2010 = 56000, PopulationYear2000 = 26000, PopulationYear1990 = 41000 });
			list.Add(new CityPopulation { CityName = "Berhampur", PopulationYear2020 = 37000, PopulationYear2010 = 44000, PopulationYear2000 = 28000, PopulationYear1990 = 48000 });
			list.Add(new CityPopulation { CityName = "Odisha", PopulationYear2020 = 40000, PopulationYear2010 = 38000, PopulationYear2000 = 30000, PopulationYear1990 = 54000 });

			return list;

		}
	}
}
