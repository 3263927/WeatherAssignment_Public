using Abstract;
using GoogleMapsAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenWeatherMapClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Classes;
using WeatherAPI.Models;

namespace Tests
{
	[TestClass]
	public class Integration_Test
	{
		public static IConfigurationRoot Configuration { get; set; }
		[TestMethod]
		public async Task AllAPI_Test()
		{

			DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory());
			DirectoryInfo temp = info.Parent.Parent.Parent.Parent;
			String CurDir = Path.Combine(temp.ToString(), "WeatherAPI");
			Configuration = new ConfigurationBuilder().SetBasePath(CurDir).AddJsonFile("appsettings.json").Build();
			ApiKeys keys = Configuration.GetSection("ApiKeys").Get<ApiKeys>();

			APISetup setup_google = new APISetup();
			setup_google.APIKey = keys.GoogleAPIKey;

			APISetup setup_OWM = new APISetup();
			setup_OWM.APIKey = keys.OpenWeatherMapsKey;
			OWMAPI wapi = new OWMAPI(setup_OWM);
			GTimeZoneAPI gapi = new GTimeZoneAPI(setup_google);

			GElevationAPI eapi = new GElevationAPI(setup_google);

			WeatherAPI.Classes.Weather w = new WeatherAPI.Classes.Weather(gapi, wapi, eapi);

			WeatherModel m = await w.GetWeather("105043","");

			Assert.AreEqual("Moscow", m.City);
			Assert.AreEqual(3, m.TimeOffset);
			Assert.AreEqual(139, Math.Round(m.Elevation));
			Assert.IsNull(m.Error);
		}
	}
}
