using System;
using com.gargoylesoftware.htmlunit;
using com.gargoylesoftware.htmlunit.html;

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
		}

		internal WebClient WebClient { get { return _htmlUnit; } }

		internal HtmlPage CurrentPage { get { return _currentPage; } }

			public ITextField CreateTextField(string id)
		{
			throw new NotImplementedException();
		}

		public ICreateControl<ITextField> CreateTextField()
		{
			return new TextFieldFactory(this);
		}

		public IButton CreateButton(string id)
		{
			throw new NotImplementedException();
		}

		public ICreateControl<IButton> CreateButton()
		{
			return new ButtonFactory();
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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public void CreateCookie(string cookieName, string value)
		{
			throw new NotImplementedException();
		}

		public bool IsTextPresent(string text)
		{
			throw new NotImplementedException();
		}

		public IContainerController<T> CreateArray<T>(string xpathExpression, Func<ICollectionElementDriver, T> createElementFunction)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			// This class doesn't need disposing
		}
	}

	public class ButtonFactory : ICreateControl<IButton>
	{
		public IButton FromID(string id)
		{
			return null;
		}

		public IButton FromCss(string css)
		{
			throw new NotImplementedException();
		}

		public IButton FromName(string name)
		{
			throw new NotImplementedException();
		}
	}
}
