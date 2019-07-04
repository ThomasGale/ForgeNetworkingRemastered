﻿using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using BeardedManStudios.SimpleJSON;
using NUnit.Framework;

namespace BeardedManStudios.Forge.Tests.SimpleJSONEditor
{
	[TestFixture]
	public class JSONNodeTests
	{
		[Test]
		public void ParseInvariantCultureTest()
		{
			var storedCulture = Thread.CurrentThread.CurrentCulture;
			JSONNode jsonNode;
			float expected = 0.15f;
			float actual;
			try
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
				var jsonString = String.Format("{{ floatTest: {0} }}", expected.ToString(CultureInfo.InvariantCulture));
				jsonNode = JSON.Parse(jsonString);
				actual = jsonNode.Children.FirstOrDefault().AsFloat;
			}
			finally
			{
				Thread.CurrentThread.CurrentCulture = storedCulture;
			}
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ParseCommaDecimalSeparatorCultureTest()
		{
			var storedCulture = Thread.CurrentThread.CurrentCulture;
			JSONNode jsonNode;
			float expected = 0.15f;
			float actual;
			try
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("fi-FI");
				var jsonString = String.Format("{{ floatTest: {0} }}", expected.ToString(CultureInfo.InvariantCulture));
				jsonNode = JSON.Parse(jsonString);
				actual = jsonNode.Children.FirstOrDefault().AsFloat;
			}
			finally
			{
				Thread.CurrentThread.CurrentCulture = storedCulture;
			}
			//var floatValue = jsonNode.AsFloat;
			Assert.AreEqual(expected, actual);
		}
	}
}