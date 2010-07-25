using System;
using com.gargoylesoftware.htmlunit.html;

namespace WebTestFramework.HtmlUnit
{
	internal class HtmlElementFactory
	{
		public HtmlElementFactory(HtmlUnitDriver driver)
		{
			_driver = driver;
		}

		private HtmlUnitDriver _driver;

		protected Func<HtmlElement> ElementFromID(string id)
		{
			return () => _driver.CurrentPage.getElementById(id);
		}

		protected Func<HtmlElement> ElementFromXPath(string xpath)
		{
			return () => (HtmlElement)_driver.CurrentPage.getFirstByXPath(xpath);
		}
	}
}