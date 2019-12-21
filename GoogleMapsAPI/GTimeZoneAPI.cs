using Abstract;
using API_Reader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Extensions;

namespace GoogleMapsAPI
{
	public class GTimeZoneAPI : ITimeZoneAPI
	{
		private String URL = "https://maps.googleapis.com/maps/api/timezone/json?";
		private String APIKey { get; set; }
		public GTimeZoneAPI(APISetup options)
		{
			APIKey = options.APIKey;
		}
		public async Task<ITimeZoneInfo> GetTimeInfo(double Latitude, double Longitude)
		{
			DateTime tdt = DateTime.UtcNow;
			String timestamp = tdt.ToTimestamp().ToString();
			String temp = URL + "location=" + Latitude + "," + Longitude + "&timestamp="+timestamp+"&key=" + APIKey;
			try
			{
				GTimeInfo info = await APIReader.ReadAPI<GTimeInfo>(temp);
				info.NormalizedOffset = tdt.AddSeconds(info.rawOffset + info.dstOffset);
				return info;
			}
			catch (Exception e)
			{
				return new GTimeInfo { Error = e.Message };
			}
			
		}
	}
}
