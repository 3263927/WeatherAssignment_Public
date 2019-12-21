using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapsAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAPI.Models;
using WeatherAPI;
using System.Runtime.InteropServices;
using WeatherAPI.Classes;

namespace WeatherAPI.API
{
    //host/api/v1.0/WeatherTime/[zip/cityname]/[country code(optional)]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/WeatherTime")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
		private readonly Weather weather;

		public WeatherController (Weather w)
		{
			weather = w;
		}

        [HttpGet("{Query}/{CountryCode?}")]
        public async Task<IActionResult> Get(String Query, String CountryCode)
        {
			WeatherModel m = new WeatherModel();
            m = await weather.GetWeather(Query, CountryCode);
			return Ok(JsonConvert.SerializeObject(m));
        }
    }
}