using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
	public interface IWeatherAPI
	{
		public Task<IWeatherInfo> GetWeatherInfo(String ZipCode);
		public Task<IWeatherInfo> GetWeatherInfo(String ZipCode, String CountryCode);
	}

	public interface IWeatherInfo
	{
		public double Temperature { get; set; }
		public String CityName { get; set; }
	}
}
