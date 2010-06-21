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
		public ISelenium Selenium { get { return _selenium; } }

		/// <summary>
		/// Creates a <see cref="ITextField"/> instance that can be used
		/// to control a single text field on a web page form.
		/// </summary>
		/// <param name="id">
		/// The ID of the text field on the form.
		/// </param>
		public virtual ITextField CreateTextField(string id)
		{
			return CreateTextField().FromID(id);
		}

		/// <summary>
		/// Creates an <see cref="ICreateControl{T}"/> for creating an
		/// <see cref="ITextField"/> implementation
		/// </summary>
		public virtual ICreateControl<ITextField> CreateTextField()
		{
			return new SeleniumDelegateControlFactory<ITextField>(CreateTextFieldControl);
		}

		/// <summary>
		/// Creates an <see cref="ICreateControl{T}"/> for creating an
		/// <see cref="IImage"/> implementation
		/// </summary>
		public virtual ICreateControl<IImage> CreateImage()
		{
			return new SeleniumDelegateControlFactory<IImage>(CreateImageControl);
		}

		/// <summary>
        /// Creates an <see cref="IButton"/> implementation that can be used to
        /// control a single button on a web page.
        /// </summary>
        /// <param name="id">
        /// The ID attribute of the button on the web page.
        /// </param>
		public virtual IButton CreateButton(string id)
        {
			return CreateButton().FromID(id);
        }

		/// <summary>
		/// Creates an <see cref="ICreateControl{T}"/> for creating an
		/// <see cref="IButton"/> implementation
		/// </summary>
		public virtual ICreateControl<IButton> CreateButton()
		{
			return new SeleniumDelegateControlFactory<IButton>(CreateButtonControl);
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
				var result = _selenium.GetCookieByName(cookieName);
				return result == "undefined" ? null : result;
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
		/// Gets the URL that is currently open in the browser.
		/// </summary>
		/// <returns>
		/// A url relative to the root of the application
		/// </returns>
		public string GetCurrentRelativeUrl()
		{
			var currentLocation = _selenium.GetLocation();
			var url = new Uri(currentLocation);
			return url.PathAndQuery;
		}

		/// <summary>
		/// Deletes a cookie in the browser
		/// </summary>		
		public void DeleteCookie(string cookieName)
		{
			_selenium.DeleteCookie(cookieName, "path=/");
		}

		/// <summary>
		/// Creates a cookie in the browser
		/// </summary>
		/// <param name="cookieName">
		/// The name of the cookie
		/// </param>
		/// <param name="value">
		/// The value of the cookie
		/// </param>
		public void CreateCookie(string cookieName, string value)
		{
			var nameValueString = string.Format(
				"{0}={1}",
				cookieName, value);
			_selenium.CreateCookie(nameValueString, "path=/");
		}

		/// <summary>
		/// Gets whether or not a specific text appears on the current page
		/// </summary>
		/// <param name="text">
		/// The text to search for
		/// </param>
		/// <returns>
		/// <c>true</c> if the text was found; otherwise <c>false</c>
		/// </returns>
		public bool IsTextPresent(string text)
		{
			return _selenium.IsTextPresent(text);
		}

		public IContainerController<T> CreateArray<T>(string xpathExpression,Func<ICollectionElementDriver, T> createElementFunction)
		{
			return new SeleniumContainerController<T>(this, xpathExpression, createElementFunction);
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

		#region Control factory functions

		/// <summary>
		/// The factory method used to create an <see cref="ITextField"/> 
		/// control for a specific locator.
		/// </summary>
		internal protected virtual ITextField CreateTextFieldControl(string locator)
		{
			return new SeleniumTextField(_selenium, locator);
		}

		/// <summary>
		/// The factory method used to create an <see cref="IButton"/> 
		/// control for a specific locator.
		/// </summary>
		internal protected virtual IButton CreateButtonControl(string locator)
		{
			return new SeleniumButton(_selenium, locator);
		}

		internal protected virtual IRadioButton CreateRadioButtonControl(string locator)
		{
			return new SeleniumRadioButton(_selenium, locator);
		}

		/// <summary>
		/// The factory method used to create an <see cref="IImage"/>
		/// control for a specific locator.
		/// </summary>
		internal protected virtual IImage CreateImageControl(string locator)
		{
			return new SeleniumImage(_selenium, locator);
		}

		#endregion

		/// <summary>
        /// Disposes this instance. This function will stop the selenium driver.
        /// </summary>
	    public void Dispose()
	    {
            _selenium.Stop();
	    }
	}
}