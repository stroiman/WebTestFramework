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
        /// Gets or sets the default timeout in milliseconds for wait operations.
        /// </summary>
	    public static int DefaultTimeout = 5000;

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
		/// Gets a reference to the <see cref="ISelenium"/> implementation passed
		/// during construction
		/// </summary>
		protected ISelenium Selenium { get { return _selenium; } }

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
        /// Creates an <see cref="IButton"/> implementation that can be used to
        /// control a single button on a web page.
        /// </summary>
        /// <param name="id">
        /// The ID attribute of the button on the web page.
        /// </param>
        public IButton CreateButton(string id)
        {
            return new SeleniumButton(_selenium, id);
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
		/// Gets the value of a cookie in the browser
		/// </summary>
		/// <param name="cookieName">
		/// The name of the cookie.
		/// </param>
		/// <returns>
		/// The value of the cookie, if it exists; otherwise <c>null</c>
		/// </returns>
		public string GetCookie(string cookieName)
		{
			try
			{
				return _selenium.GetCookieByName(cookieName);
			}
			catch(SeleniumException)
			{
				// According to the interface documentation, Selenium will 
				// throw an error, if the cookie doesn't exist.
				// It can be difficult to know here however, if the exception
				// is caused by the cookie not existing, or some other
				// communication problem with Selenium RC or the browser.
				// Here we treat it as though it is the cookie that doesn't
				// exist
				return null;
			}
		}

		/// <summary>
		/// Creates a new <see cref="SeleniumDriver"/> instance.
		/// </summary>
		/// <param name="seleniumServerHost">
		/// The host that is running Selenium RC
		/// </param>
		/// <param name="rootUrl">
		/// The url where the site to test exists.
		/// </param>
		/// <param name="browserString">
		/// The browser string identifying which browser to start
		/// </param>
		/// <returns></returns>
		public static SeleniumDriver Create(string seleniumServerHost, string rootUrl, string browserString = "*iexplore")
        {
            // This function is not covered by a test, because I don't know how to validate
            // that selenium is constructed correctly. Also starting selenium requires a
            // selenium RC server running, and I don't think that the work of creating a fake
            // selenium server listening to a custom port is worth the effort to test these 3
            // lines of code
			var selenium = new DefaultSelenium(seleniumServerHost, 4444, browserString, rootUrl);
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