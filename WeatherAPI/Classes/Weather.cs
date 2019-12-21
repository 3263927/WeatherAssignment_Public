using Abstract;
using GoogleMapsAPI;
using OpenWeatherMapClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Classes
{
	public class Weather
	{
		private readonly ITimeZoneAPI TimeAPI;
		private readonly IWeatherAPI WeatherAPI;
		private readonly IElevationAPI ElevationAPI;

		public Weather(ITimeZoneAPI TimeAPI, IWeatherAPI WeatherAPI, IElevationAPI ElevationAPI)
		{
			this.TimeAPI = TimeAPI;
			this.WeatherAPI = WeatherAPI;
			this.ElevationAPI = ElevationAPI;
		}

		public async Task<WeatherModel> GetWeather(String Query, String CountryCode)
		{
			WeatherModel m = new WeatherModel();
			m.ZipCode = Query;
			m.CountryCode = CountryCode;
			WeatherInfo weather = await WeatherAPI.GetWeatherInfo(Query, CountryCode) as WeatherInfo;
			if (weather.Error != null)
			{
				m.Error = "WeatherInfo error: " + weather.Error;
			}
			else
			{
				m.Temperature_K = weather.Temperature;
				GTimeInfo time = await TimeAPI.GetTimeInfo(weather.Latitude, weather.Longitude) as GTimeInfo;
				if (time.Error != null || time.status != GTimeInfo.Status_OK)
				{
					m.Error = "TimeAPI error: " + time.Error ?? time.status;
				}
				else
				{
					m.Latitude = weather.Latitude;
					m.Longitude = weather.Longitude;
					m.TimeZone = time.timeZoneName;

					int ttime = time.rawOffset / 60;

					m.TimeOffset = TimeSpan.FromHours(time.NormalizedOffset.Hour - DateTime.UtcNow.Hour).Hours;
					m.City = weather.CityName;
					m.CurrentTime = time.NormalizedOffset.AddHours(1);

					GElevationInfo elevation = await ElevationAPI.GetElevationInfo(weather.Latitude, weather.Longitude) as GElevationInfo;

					if (elevation.Error != null)
					{
						m.Error = elevation.Error;
					}
					else
					{
						m.Elevation = elevation.Elevation;
					}
				}
			}
			if (m.Error == null)
			{
				m.Status = WeatherModel.Status_OK;
			}
			else
			{
				m.Status = WeatherModel.Status_ERROR;
			}
			return m;
		}
	}
}
