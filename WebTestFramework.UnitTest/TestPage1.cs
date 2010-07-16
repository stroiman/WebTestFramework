using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTestFramework.UnitTest
{
	public class TestPage1 : Page
	{
		public TestPage1(IBrowserDriver driver) : base(driver)
		{
		}

		public override string GetUrl()
		{
			return "/TestPage1.aspx";
		}
	}

	public class RedirectToPage1 : Page
	{
		public RedirectToPage1(IBrowserDriver driver) : base(driver)
		{
		}

		public override string GetUrl()
		{
			return "/RedirectToPage1.aspx";
		}
	}
}
