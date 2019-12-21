using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Extensions;

namespace Tests
{
	[TestClass]
	public class FunctionsTest
	{
		[TestMethod]
		public void Temperatures_Conversion_FC_Test()
		{
			double F = Functions.CtoF(0);
			double C = Functions.FtoC(F);

			Assert.AreEqual(32, F);
			Assert.AreEqual(0, C);
		}

		[TestMethod]
		public void Temperatures_Conversion_CK_Test()
		{
			double C = Functions.KtoC(0);
			double K = Functions.CtoK(C);

			Assert.AreEqual(-273.15, C);
			Assert.AreEqual(0, K);
		}

		[TestMethod]
		public void Temperatures_Conversion_FK_Test()
		{
			double F = Functions.KtoF(0);
			double K = Functions.FtoK(F);

			Assert.AreEqual(-459.67, Math.Round(F,2));
			Assert.AreEqual(0.35, Math.Round(K,2));
		}
	}
}
