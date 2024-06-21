using Charts_In_MVC.Models;

namespace Charts_In_MVC.DAL
{
    public class PopulationDAL
    {
        public static List<PopulationModel> GetCityPopulationList()
        {
            var list = new List<PopulationModel>();
            list.Add(new PopulationModel("PURI", 28000, 45000, 22000, 50000));
            list.Add(new PopulationModel ("Bhubaneswar",30000, 49000,24000, 39000 ));
            list.Add(new PopulationModel ("Cuttack", 35000,56000,26000, 41000 ));
            list.Add(new PopulationModel ("Berhampur",37000, 44000, 28000,48000 ));
            list.Add(new PopulationModel ("Odisha", 40000, 38000, 30000,  54000 ));

            return list;

        }
    }
}
