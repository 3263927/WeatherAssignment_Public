using Abstract;
using API_Reader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsAPI
{
	public class GElevationAPI : IElevationAPI
	{
		private String URL = "https://maps.googleapis.com/maps/api/elevation/json?";
		private String APIKey { get; set; }
		public GElevationAPI(APISetup options)
		{
			APIKey = options.APIKey;
		}

		public async Task<IElevationInfo> GetElevationInfo(double Latitude, double Longitude)
		{
			String temp = URL + "locations=" + Latitude + "," + Longitude + "&key=" + APIKey;
			try
			{
				GoogleElevation info = await APIReader.ReadAPI<GoogleElevation>(temp);

				if (info.status == GElevationInfo.Status_OK)
				{
					if (info.results.Count > 0)
					{
						GElevationInfo ninfo = new GElevationInfo();
						ninfo.location = info.results[0].location;
						ninfo.Resolution = info.results[0].resolution;
						ninfo.Elevation = info.results[0].elevation;
						return ninfo;
					}
					else
					{
						return new GElevationInfo { Error = "results <0 in GetElevationInfo" };
					}
				}
				else
				{
					return new GElevationInfo { Error = info.status };
				}
			}
			catch (Exception e)
			{
				return new GElevationInfo { Error = e.Message };
			}
		}
	}
	

	public class Result
	{
		public double elevation { get; set; }
		public GLocation location { get; set; }
		public double resolution { get; set; }
	}

	public class GoogleElevation
	{
		public List<Result> results { get; set; }
		public string status { get; set; }
	}
}
