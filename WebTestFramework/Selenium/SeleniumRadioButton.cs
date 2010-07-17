using Selenium;

namespace WebTestFramework.Selenium
{
	/// <summary>
	/// A controller for a radio button on a web page.
	/// </summary>
	public class SeleniumRadioButton : SeleniumControlBase, IRadioButton
	{
		/// <summary>
		/// Creates a new <see cref="SeleniumRadioButton"/> instance.
		/// </summary>
		public SeleniumRadioButton(ISelenium selenium, string locator)
			: base(selenium, locator)
		{ }

		/// <summary>
		/// Selects the radio button.
		/// </summary>
		public void Select()
		{
			Selenium.Click(Locator);
		}
	}
}