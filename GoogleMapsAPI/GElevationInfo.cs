using Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapsAPI
{
	public class GElevationInfo : IElevationInfo, IAPIInfo
	{
		public static String Status_OK = "OK";

		public double Elevation { get; set; }
		public double Resolution { get; set; }
		public GLocation location { get; set; }
		public String Error { get; set; }

		public List<Result> results { get; set; }
		public string status { get; set; }
	}
}
