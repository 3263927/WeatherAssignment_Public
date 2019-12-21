using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenWeatherMapClasses;
using System;

namespace Tests
{
	[TestClass]
	public class OWM_Tests
	{
		public static String WData="{\"coord\":{\"lon\":-0.13,\"lat\":51.51},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"base\":\"stations\",\"main\":{\"temp\":284.71,\"feels_like\":279.43,\"temp_min\":283.15,\"temp_max\":286.15,\"pressure\":992,\"humidity\":76},\"visibility\":10000,\"wind\":{\"speed\":6.7,\"deg\":150},\"rain\":{\"3h\":0.44},\"clouds\":{\"all\":100},\"dt\":1576784332,\"sys\":{\"type\":1,\"id\":1414,\"country\":\"GB\",\"sunrise\":1576742550,\"sunset\":1576770742},\"timezone\":0,\"id\":2643743,\"name\":\"London\",\"cod\":200}";

		[TestMethod]
		public void JSON_Conversion_Test()
		{
			OWM w = JsonConvert.DeserializeObject<OWM>(WData);
			Assert.AreEqual(284.71, w.main.temp);
			Assert.AreEqual(1, w.weather.Count);
		}
	}
}