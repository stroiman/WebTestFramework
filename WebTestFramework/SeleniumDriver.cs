using System;
using Selenium;

namespace WebTestFramework
{
	/// <summary>
	/// A class that provides an abstraction layer on top of Selenium RC.
	/// </summary>
	public class SeleniumDriver : IBrowserDriver, IDisposable
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

        /// <summary>
        /// Opens a url relative to the root url used to construct the selenium driver,
        /// or passed to the <see cref="Create"/> function
        /// </summary>
        /// <param name="relativeUrl"></param>
		public void Open(string relativeUrl)
		{
			_selenium.Open(relativeUrl);
		}

        /// <summary>
        /// Creates a new <see cref="SeleniumDriver"/> instance.
        /// </summary>
        /// <param name="seleniumServerHost">
        /// 
        /// </param>
        /// <param name="rootUrl"></param>
        /// <returns></returns>
        public static SeleniumDriver Create(string seleniumServerHost, string rootUrl)
        {
            // This function is not covered by a test, because I don't know how to validate
            // that selenium is constructed correctly. Also starting selenium requires a
            // selenium RC server running, and I don't think that the work of creating a fake
            // selenium server listening to a custom port is worth the effort to test these 3
            // lines of code
            var selenium = new DefaultSelenium(seleniumServerHost, 4444, "*iexplore", rootUrl);
            selenium.Start();
            return new SeleniumDriver(selenium);
        }

        /// <summary>
        /// Disposes this instance. This function will stop the selenium driver.
        /// </summary>
	    public void Dispose()
	    {
            _selenium.Stop();
	    }
	}
}
