namespace WebTestFramework
{
	/// <summary>
	/// Base class for creating specialized page control classes for controlling
	/// and validating the behaviour of a specific page in the system.
	/// </summary>
	/// <remarks>
	/// For each page in the system, you should create a specialization of the
	/// <see cref="Page"/> class, with properties corresponding to the input
	/// fields, buttons, etc. that you wish to control
	/// </remarks>
	public abstract class Page
	{
		private readonly IBrowserDriver _driver;

		/// <summary>
		/// Creates a new <see cref="Page"/> instance
		/// </summary>
		/// <param name="driver">
		/// A reference to th <see cref="IBrowserDriver"/> implementation used to 
		/// control the browser.
		/// </param>
		protected Page(IBrowserDriver driver)
		{
			_driver = driver;
		}

		/// <summary>
		/// Creates an <see cref="ITextField"/> implementation that can be used
		/// to control a single text field on a web page form.
		/// </summary>
		/// <param name="id">
		/// The ID of the text field on the form.
		/// </param>
		public ITextField CreateTextField(string id)
		{
			return _driver.CreateTextField(id);
		}

		/// <summary>
		/// Template method for retrieving the relative URL of the page.
		/// Specialized classes must override this function and supply the
		/// relative URL where the actual page can be found.
		/// </summary>
		public abstract string GetUrl();

		/// <summary>
		/// Opens the page in the browser controlled by the 
		/// <see cref="IBrowserDriver"/> implementation passed to the
		/// <see cref="Page(IBrowserDriver)"/> constructor
		/// </summary>
		public void Open()
		{
			_driver.Open(GetUrl());
		}
	}
}
