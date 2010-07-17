using System;

namespace WebTestFramework.HtmlUnit
{
	/// <summary>
	/// An implementation of <see cref="IBrowserDriver"/> that works with HtmlUnit,
	/// a component that emulates a driver, but without a graphical user interface.
	/// </summary>
	public class HtmlUnitDriver : IBrowserDriver
	{
		public ITextField CreateTextField(string id)
		{
			throw new NotImplementedException();
		}

		public ICreateControl<ITextField> CreateTextField()
		{
			throw new NotImplementedException();
		}

		public IButton CreateButton(string id)
		{
			throw new NotImplementedException();
		}

		public ICreateControl<IButton> CreateButton()
		{
			throw new NotImplementedException();
		}

		public ICreateControl<IImage> CreateImage()
		{
			throw new NotImplementedException();
		}

		public void Open(string relativeUrl)
		{
			throw new NotImplementedException();
		}

		public string GetCookie(string cookieName)
		{
			throw new NotImplementedException();
		}

		public string GetCurrentRelativeUrl()
		{
			throw new NotImplementedException();
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
	}
}
