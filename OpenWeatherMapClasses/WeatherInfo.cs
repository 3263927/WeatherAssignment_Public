using Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapClasses
{
	public class WeatherInfo : IWeatherInfo, IAPIInfo
	{
		public double Temperature { get; set; }
		public string CityName { get; set; }

		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public String Error { get; set; }
	}
}
