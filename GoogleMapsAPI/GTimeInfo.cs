using System;

namespace GoogleMapsAPI
{
	public class GTimeInfo:ITimeZoneInfo
	{
		public static String Status_OK = "OK";

		public int dstOffset { get; set; }
		public int rawOffset { get; set; }
		public String status { get; set; }
		public String timeZoneId { get; set; }
		public String timeZoneName { get; set; }
		public DateTime NormalizedOffset { get; set; }
		public String Error = null;
	}
}
