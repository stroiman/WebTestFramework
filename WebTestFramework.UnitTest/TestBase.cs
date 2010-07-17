using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium;
using WebTestFramework.HtmlUnit;
using WebTestFramework.Selenium;

namespace WebTestFramework.UnitTest
{
	[SetUpFixture]
	public class SetupFixture
	{
		private static IBrowserDriver _driver;

		[SetUp]
		public void Setup()
		{
			const string rootUrl = "http://localhost:65488/";
			//var selenium = new DefaultSelenium("localhost", 4444, "*iexploreproxy", rootUrl);
			//selenium.Start();
			//_driver = new SeleniumDriver(selenium);
			_driver = new HtmlUnitDriver(rootUrl);
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Dispose();
		}

		public static IBrowserDriver Driver { get { return _driver; } }
	}

	public class TestBase
	{
		protected IBrowserDriver Driver { get { return SetupFixture.Driver; } }
	}
}
