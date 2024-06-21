using System.Runtime.Serialization;

namespace Charts_In_MVC.Models
{
	[DataContract]
	public class PopulationModel
    {
		[DataMember(Name = "cityName")]
		public string CityName = "";

		[DataMember(Name = "populationYear2020")]
		public Nullable<int> PopulationYear2020 = null;

		[DataMember(Name = "populationYear2010")]
		public Nullable<int> PopulationYear2010 = null;

		[DataMember(Name = "populationYear2000")]
		public Nullable<int> PopulationYear2000 = null;

		[DataMember(Name = "populationYear1990")]
		public Nullable<int> PopulationYear1990 = null;



		public PopulationModel(string cityName, int populationYear2020,int populationYear2010,int populationYear2000,int populationYear1990)
		{
			this.CityName = cityName;
			this.PopulationYear2020 = populationYear2020;
			this.PopulationYear2010 = populationYear2010;
			this.PopulationYear2000 = populationYear2000;
			this.PopulationYear1990 = populationYear1990;
		}
	}
}
