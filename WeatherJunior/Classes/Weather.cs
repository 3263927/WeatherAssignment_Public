using System;
using System.IO;
using System.Net;

namespace WeatherJunior.Classes
{
	public class Weather
	{
		public String GoogleKey = "";
		public String WeatherKey = "";
		public String GetWeather(String Query)
		{
			String WeatherURL = "https://api.openweathermap.org/data/2.5/weather?q="+Query+ "&APPID=" + WeatherKey;
			return GetResponse(WeatherURL);
		}

		public String GetTime(String Lat, String Lon)
		{
			String TimeURL = "https://maps.googleapis.com/maps/api/timezone/json?" + "location=" + Lat + "," + Lon + "&timestamp=0" + "&key=" + GoogleKey;
			return GetResponse(TimeURL);
		}

		public String GetElevation(String Lat, String Lon)
		{
			String ElevationURL = "https://maps.googleapis.com/maps/api/elevation/json?" + "locations="+Lat + "," + Lon + "&key="+GoogleKey;
			return GetResponse(ElevationURL);
		}

		private String GetResponse(String URL)
		{
			WebRequest request = WebRequest.Create(URL);

			request.Headers["Authorization"] = "Basic ";
			request.Method = "POST";

			Stream dataStream = request.GetRequestStream();

			WebResponse response = request.GetResponse();
			dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			String responseFromServer = reader.ReadToEnd();

			reader.Close();
			response.Close();
			dataStream.Close();

			return responseFromServer;
		}
	}
}
