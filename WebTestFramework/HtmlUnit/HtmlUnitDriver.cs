using System;
using com.gargoylesoftware.htmlunit;
using com.gargoylesoftware.htmlunit.html;
using com.gargoylesoftware.htmlunit.util;

namespace WebTestFramework.HtmlUnit
{
	/// <summary>
	/// An implementation of <see cref="IBrowserDriver"/> that works with HtmlUnit,
	/// a component that emulates a driver, but without a graphical user interface.
	/// </summary>
	public class HtmlUnitDriver : IBrowserDriver
	{
		private readonly string _rootUrl;
		private readonly WebClient _htmlUnit;
		private HtmlPage _currentPage;

		/// <summary>
		/// Creates a new <see cref="HtmlUnitDriver"/> instance.
		/// </summary>
		/// <param name="rootUrl">
		/// The absolute root url of the web application to test.
		/// </param>
		public HtmlUnitDriver(string rootUrl)
		{
			_rootUrl = rootUrl;
			_htmlUnit = new WebClient();
			_htmlUnit.setThrowExceptionOnFailingStatusCode(false);
		}

		internal protected WebClient WebClient { get { return _htmlUnit; } }

		internal protected HtmlPage CurrentPage
		{
			get
			{
				return (HtmlPage)WebClient.getCurrentWindow().getEnclosedPage();
			}
		}

		public ICreateControl<ITextField> CreateTextField()
		{
			return new TextFieldFactory(this);
		}

		public ICreateControl<IButton> CreateButton()
		{
			return new HtmlUnitButtonFactory(this);
		}

		public ICreateControl<IImage> CreateImage()
		{
			throw new NotImplementedException();
		}

		public void Open(string relativeUrl)
		{
			var url = string.Format("{0}/{1}",
				_rootUrl.TrimEnd('/'),
				relativeUrl.TrimStart('/'));
			_currentPage = (HtmlPage)_htmlUnit.getPage(url);
		}

		public string GetCookie(string cookieName)
		{
			var cookie = _htmlUnit.getCookieManager().getCookie(cookieName);
			return cookie == null ? null : cookie.getValue();
		}

		public string GetCurrentRelativeUrl()
		{
			var result = CurrentPage
				.getWebResponse()
				.getRequestSettings()
				.getUrl();

			return result.getPath();
		}

		public void DeleteCookie(string cookieName)
		{
			CreateCookie(cookieName, "");
		}

		public void CreateCookie(string cookieName, string value)
		{
			var cookies = _htmlUnit.getCookieManager();
			var uri = new Uri(_rootUrl);
			var domain = uri.Host;
			var cookie = new Cookie(domain, cookieName, value, "/", 120, false);
			cookies.addCookie(cookie);
		}

		public bool IsTextPresent(string text)
		{
			throw new NotImplementedException();
		}

		public IContainerController<T> CreateArray<T>(string xpathExpression, Func<ICollectionElementDriver, T> createElementFunction)
		{
			return new HtmlUnitContainerController<T>(this, xpathExpression, createElementFunction);
		}

		public void Dispose()
		{
			// This class doesn't need disposing
		}
	}
}
