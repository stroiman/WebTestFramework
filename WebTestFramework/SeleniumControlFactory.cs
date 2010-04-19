using Selenium;

namespace WebTestFramework
{
	/// <summary>
	/// A base class for implementing the generic 
	/// <see cref="ICreateControl{T}"/> interface.
	/// </summary>
	public abstract class SeleniumControlFactory<T> : ICreateControl<T>
	{
		/// <summary>
		/// Template function that the specialized classes should implement
		/// to create the actual control
		/// </summary>
		/// <param name="locator">
		/// The selenium locator string that the control should use.
		/// </param>
		protected abstract T CreateControl(string locator);

		/// <summary>
		/// Creates a control from the element ID.
		/// </summary>
		public T FromID(string id)
		{
			return CreateControl("id=" + id);
		}

		/// <summary>
		/// Creates a control from a CSS locator
		/// </summary>
		public T FromCSS(string cssLocator)
		{
			return CreateControl("css=" + cssLocator);
		}
	}

	/// <summary>
	/// A class that is used to create <see cref="SeleniumTextField"/> 
	/// instances.  This is the return value from the 
	/// <see cref="SeleniumDriver.CreateTextField()"/> function.
	/// </summary>
	public class SeleniumTextFieldFactory : SeleniumControlFactory<ITextField>
	{
		private readonly ISelenium _selenium;

		/// <summary>
		/// Creates a new <see cref="SeleniumTextFieldFactory"/> instance
		/// </summary>
		public SeleniumTextFieldFactory(ISelenium selenium)
		{
			_selenium = selenium;
		}

		/// <summary>
		/// Creates the actual <see cref="ITextField"/> to be used
		/// </summary>
		protected override ITextField CreateControl(string locator)
		{
			return new SeleniumTextField(_selenium, locator);
		}
	}

	/// <summary>
	/// A class that is used to create <see cref="SeleniumButton"/> instances.
	/// This is the return value from the 
	/// <see cref="SeleniumDriver.CreateButton()"/> function.
	/// </summary>
	public class SeleniumButtonFactory : SeleniumControlFactory<IButton>
	{
		private readonly ISelenium _selenium;

		/// <summary>
		/// Creates a new <see cref="SeleniumButtonFactory"/> instance
		/// </summary>
		/// <param name="selenium"></param>
		public SeleniumButtonFactory(ISelenium selenium)
		{
			_selenium = selenium;
		}

		/// <summary>
		/// Creates the actual <see cref="IButton"/> to be used
		/// </summary>
		protected override IButton CreateControl(string locator)
		{
			return new SeleniumButton(_selenium, locator);
		}
	}
}