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
	public class Page
	{
		private readonly IBrowserDriver _driver;

		/// <summary>
		/// Creates a new <see cref="Page"/> instance
		/// </summary>
		/// <param name="driver">
		/// A reference to th <see cref="IBrowserDriver"/> implementation used to 
		/// control the browser.
		/// </param>
		public Page(IBrowserDriver driver)
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
	}
}
