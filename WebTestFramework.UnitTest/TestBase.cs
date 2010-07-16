﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace WebTestFramework.UnitTest
{
	[SetUpFixture]
	public class SetupFixture
	{
		private static Selenium.DefaultSelenium _selenium;
		private static SeleniumDriver _driver;

		[SetUp]
		public void Setup()
		{
			_selenium = new Selenium.DefaultSelenium("localhost", 4444, "*iexploreproxy", "http://localhost:65488/");
			_selenium.Start();
			_driver = new SeleniumDriver(_selenium);
		}

		[TearDown]
		public void TearDown()
		{
			_selenium.Close();
		}

		public static IBrowserDriver Driver { get { return _driver; } }
	}

	public class TestBase
	{
		protected IBrowserDriver Driver { get { return SetupFixture.Driver; } }
	}
}