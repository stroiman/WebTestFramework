using Selenium;

namespace WebTestFramework
{
	/// <summary>
	/// A class that provides an abstraction layer on top of Selenium RC.
	/// </summary>
	public class SeleniumDriver : IBrowserDriver
	{
		private readonly ISelenium _selenium;

		/// <summary>
		/// Creates a new <see cref="SeleniumDriver"/> instance.
		/// </summary>
		/// <param name="selenium">
		/// The <see cref="ISelenium"/> implementation used to 
		/// remote control the browser.
		/// </param>
		public SeleniumDriver(ISelenium selenium)
		{
			_selenium = selenium;
		}

		/// <summary>
		/// Creates a <see cref="ITextField"/> instance that can be used
		/// to control a single text field on a web page form.
		/// </summary>
		/// <param name="id">
		/// The ID of the text field on the form.
		/// </param>
		public ITextField CreateTextField(string id)
		{
			return new SeleniumTextField(_selenium, id);
		}
	}
}
