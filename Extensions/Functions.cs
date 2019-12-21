using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
	public static class Functions
	{
		public static double FtoC(double Fahrenheit)
		{
			double Celsius = 5.0d / 9.0d * (Fahrenheit - 32.0d);

			return Celsius;
		}

		public static double CtoF(double Celsius)
		{
			double Fahrenheit = (Celsius * 9.0d) / 5.0d + 32.0d;
			return Fahrenheit;
		}

		public static double FtoK(double Fahrenheit)
		{
			double Kelvin = 273.5f + ((Fahrenheit - 32.0f)*(5.0f / 9.0f));
			return Kelvin;
			
		}

		public static double KtoF(double Kelvin)
		{
			double Fahrenheit = 1.8f * (Kelvin - 273.15f) + 32.0f;
			return Fahrenheit;
		}

		public static double KtoC(double Kelvin)
		{
			double Celsius = Kelvin - 273.15d;
			return Celsius;
		}

		public static double CtoK(double Celsius)
		{
			double Kelvin = Celsius + 273.15d;
			return Kelvin;
		}
	}
}
