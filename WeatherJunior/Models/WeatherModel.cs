using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherJunior.Models
{
	public class WeatherModel
	{
		public String ZipCode { get; set; }
		public String TimeZone { get; set; }
		public String City { get; set; }
		public String Elevation { get; set; }
		public String Temperature { get; set; }
		public String Lon { get; set; }
		public String Lat { get; set; }

	}
}
