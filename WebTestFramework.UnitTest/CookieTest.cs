using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace WebTestFramework.UnitTest
{
	public class CookieTestPage : Page
	{
		public readonly ITextField TextField;
		public readonly IButton Button;

		public CookieTestPage(IBrowserDriver driver) : base(driver)
		{
			TextField = driver.CreateTextField().FromID("textField");
			Button = driver.CreateButton().FromID("submitButton");
		}

		public override string GetUrl()
		{
			return "/CookieTestPage.aspx";
		}
	}

	[TestFixture]
	public class CookieTest : TestBase
	{
		[Test]
		public void SetCookie()
		{
			const string expected = "Cookie value";
			Driver.CreateCookie("TestCookie", expected);
			var page = new CookieTestPage(Driver);
			page.Open();
			Assert.That(page.TextField.Text, Is.EqualTo(expected));
		}

		[Test]
		public void GetCookie()
		{
			const string expected = "Cookie value";
			var page = new CookieTestPage(Driver);
			page.Open();
			page.TextField.Type(expected);
			page.Button.ClickAndWait();
			var actual = Driver.GetCookie("TestCookie");
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void DeleteCookie()
		{
			GetCookie(); // Use the GetCookieTest to create a cookie
			Driver.DeleteCookie("TestCookie");
			var page = new CookieTestPage(Driver);
			page.Open();
			Assert.That(page.TextField.Text, Is.EqualTo(""));
		}
	}
}
