using System;
using Selenium;

namespace WebTestFramework
{
	public class SeleniumRadioButton : SeleniumControlBase, IRadioButton
	{
		public SeleniumRadioButton(ISelenium selenium, string locator)
			: base(selenium, locator)
		{ }

		public void Select()
		{
			Selenium.Click(Locator);
		}
	}
}