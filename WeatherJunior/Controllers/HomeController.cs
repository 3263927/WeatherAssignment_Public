using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WeatherJunior.Classes;
using WeatherJunior.Models;

namespace WeatherJunior.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Weather(WeatherModel m)
		{
			Weather w = new Weather();
			
			String tweather = w.GetWeather(m.ZipCode);
			JObject twj = JObject.Parse(tweather);

			String lon = twj["coord"]["lon"].ToString();
			String lat = twj["coord"]["lat"].ToString();
			String CityName = twj["name"].ToString();
			String temperature = twj["main"]["temp"].ToString();

			String ttime = w.GetTime(lat, lon);

			JObject ttj = JObject.Parse(ttime);

			String timeZone = ttj["timeZoneName"].ToString();

			String televation = w.GetElevation(lat, lon);

			JObject tlv = JObject.Parse(televation);

			String elevation = tlv["results"][0]["elevation"].ToString();

			m.City = CityName;
			m.Elevation = elevation;
			m.TimeZone = timeZone;
			m.Temperature = temperature;
			m.Lon = lon;
			m.Lat = lat;

			return PartialView(m);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
