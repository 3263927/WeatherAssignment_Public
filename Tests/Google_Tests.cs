using GoogleMapsAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{

	[TestClass]
	public class Google_Tests
	{
		public static String GData = "{   \"dstOffset\" : 3600,   \"rawOffset\" : -18000,   \"status\" : \"OK\",   \"timeZoneId\" : \"America/New_York\",   \"timeZoneName\" : \"Eastern Daylight Time\"}";

		public static String EData = "{   \"results\" : [      {         \"elevation\" : 1608.637939453125,         \"location\" : {            \"lat\" : 39.73915360,            \"lng\" : -104.98470340		 },         \"resolution\" : 4.771975994110107      }   ],   \"status\" : \"OK\"}";

		[TestMethod]
		public void JSON_Conversion_TimeInfo_Test()
		{
			GTimeInfo info = JsonConvert.DeserializeObject<GTimeInfo>(GData);
			Assert.AreEqual("OK", info.status);
			Assert.AreEqual("America/New_York", info.timeZoneId);
		}

		[TestMethod]
		public void JSON_Conversion_ElevationInfo_Test()
		{
			GElevationInfo info = JsonConvert.DeserializeObject<GElevationInfo>(EData);
			Assert.AreEqual("OK", info.status);
			Assert.AreEqual(1, info.results.Count);
		}
	}
}
