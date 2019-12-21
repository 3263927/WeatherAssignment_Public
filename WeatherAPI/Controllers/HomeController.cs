using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherAPI.Models;
using API_Reader;
using GoogleMapsAPI;
using Microsoft.Extensions.Options;
using Abstract;
using WeatherAPI.Classes;

namespace WeatherAPI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly Weather weather;

		public HomeController(ILogger<HomeController> logger, Weather w)
		{
			_logger = logger;
			weather = w;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Weather([Bind(include: "ZipCode, CountryCode")]WeatherModel m)
		{
			if (ModelState.IsValid)
			{
				m = await weather.GetWeather(m.ZipCode, m.CountryCode);
			}
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


