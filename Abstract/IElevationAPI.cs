using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
	public interface IElevationAPI
	{
		public Task<IElevationInfo> GetElevationInfo(double Latitude, double Longitude);
	}

	public interface IElevationInfo
	{
		public double Elevation { get; set; }
	}
}
