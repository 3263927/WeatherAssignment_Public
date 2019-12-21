using Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
	public class WeatherModel
	{
		public static String Status_OK = "OK";
		public static String Status_ERROR = "Error";
		public String ZipCode { get; set; }
		[RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
		public String CountryCode { get; set; }
		public double Elevation { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public String TimeZone { get; set; }
		public int TimeOffset { get; set; }
		public String City { get; set; }
		public double Temperature_K { get; set; }
		public double Temperature_C
		{
			get
			{
				return Math.Round(Functions.FtoC(Temperature_F), 1);
			}
			private set { }
		}
		public double Temperature_F
		{
			get
			{
				return Math.Round(Functions.KtoF(Temperature_K), 1);
			}
			private set { }
		}
		public DateTime CurrentTime { get; set; }
		public String Error { get; set; }
		public String Status { get; set; }

	}
}
