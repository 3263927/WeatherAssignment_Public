using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsAPI
{
	public interface ITimeZoneAPI
	{
		public Task<ITimeZoneInfo> GetTimeInfo(double Latitude, double Longitude);
	}

	public interface ITimeZoneInfo
	{
		public int dstOffset { get; set; }
		public int rawOffset { get; set; }
		public String timeZoneName { get; set; }
	}
}
