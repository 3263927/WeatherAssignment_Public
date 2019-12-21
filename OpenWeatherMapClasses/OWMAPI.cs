using Abstract;
using API_Reader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapClasses
{
	public class OWMAPI:IWeatherAPI
	{
		public String DefaultCountry = "us";
		private String URL = "https://api.openweathermap.org/data/2.5/weather?";
		private String APIKey { get; set; }
		public OWMAPI(APISetup options)
		{
			APIKey = options.APIKey;
		}

		public async Task<IWeatherInfo> GetWeatherInfo(String ZipCode, String CountryCode)
		{
			if (!String.IsNullOrWhiteSpace(CountryCode))
			{
				CountryCode = "," + CountryCode;
			}
			String temp = URL + "q="+ZipCode+CountryCode+"&APPID=" + APIKey;
			try
			{
				OWM owm = await APIReader.ReadAPI<OWM>(temp);
				return new WeatherInfo { CityName = owm.name, Temperature = owm.main.temp, Latitude = owm.coord.lat, Longitude = owm.coord.lon };
			}
			catch (Exception e)
			{
				return new WeatherInfo { Error = e.Message };
			}
		}

		public async Task<IWeatherInfo> GetWeatherInfo(string ZipCode)
		{
			return await GetWeatherInfo(ZipCode, DefaultCountry);
		}
	}
}
