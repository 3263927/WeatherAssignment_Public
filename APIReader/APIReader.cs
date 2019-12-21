using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace API_Reader
{
	public class APIReader
	{
		public static async Task<T> ReadAPI<T>(String URL) where T:class
		{
			String WeatherURL = URL;
			WebRequest request = WebRequest.Create(WeatherURL);

			request.Headers["Authorization"] = "Basic ";
			request.Method = "POST";

			Stream dataStream = await request.GetRequestStreamAsync();


			WebResponse response = await request.GetResponseAsync();
			dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			String responseFromServer = await reader.ReadToEndAsync();

			reader.Close();
			response.Close();
			dataStream.Close();

			T temp;

			if (typeof(T) == typeof(string))
			{
				
				return (T)Convert.ChangeType(responseFromServer, typeof(T));
			}
			else
			{
				temp = JsonConvert.DeserializeObject<T>(responseFromServer);
			}
			return temp;
		}
	}
}
