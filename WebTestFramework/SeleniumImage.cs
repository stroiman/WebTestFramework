using System;
using Selenium;

namespace WebTestFramework
{
	/// <summary>
	/// An implementation of the <see cref="IImage"/> inerface that uses
	/// Selenium to implement remote control behaviour.
	/// </summary>
	public class SeleniumImage : IImage
	{
		private readonly ISelenium _selenium;
		private readonly string _locator;

		/// <summary>
		/// Creates a new <see cref="SeleniumImage"/> instance
		/// </summary>
		/// <param name="selenium">
		/// The <see cref="ISelenium"/> instance used to retrieve the actual image
		/// </param>
		/// <param name="locator">
		/// The image locator used to locate the img-tag on the web page
		/// </param>
		public SeleniumImage(ISelenium selenium, string locator)
		{
			_selenium = selenium;
			_locator = locator;
		}

		/// <summary>
		/// Gets the Src attribute from img-tag on the web page.
		/// </summary>
		public string Src
		{
			get
			{
				var locator = _locator + "@src";
				return _selenium.GetAttribute(locator);
			}
		}

		/// <summary>
		/// Gets the url local to the site. E.g. if the url for the image is
		/// http://example.com/abc/test.gif, then this property will return
		/// /abc/test.gif
		/// </summary>
		public string LocalSrc
		{
			get
			{
				var url = new Uri(Src);
				return url.AbsolutePath;
			}
		}
	}
}