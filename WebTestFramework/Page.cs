using System;

namespace WebTestFramework
{
	/// <summary>
	/// Generic Base class for creating specialized page control classes for 
	/// controlling and validating the behaviour of a specific page in the 
	/// system
	/// </summary>
	/// <remarks>
	/// For each page in the system, you should create a specialization of the
	/// <see cref="Page{T}"/> class, with properties corresponding to the input
	/// fields, buttons, etc. that you wish to control
	/// </remarks>
	/// <typeparam name="TBrowserDriver">
	/// Type type of <see cref="IBrowserDriver"/>
	/// </typeparam>
	public abstract class Page<TBrowserDriver> where TBrowserDriver : IBrowserDriver
	{
		private readonly TBrowserDriver _driver;

		/// <summary>
		/// Creates a new <see cref="Page{T}"/> instance
		/// </summary>
		/// <param name="driver">
		/// A reference to th <see cref="IBrowserDriver"/> implementation used to 
		/// control the browser.
		/// </param>
		protected Page(TBrowserDriver driver)
		{
			_driver = driver;
		}

		/// <summary>
		/// Gets a reference to the <see cref="IBrowserDriver"/> specialization
		/// used when constructing this instance.
		/// </summary>
		public TBrowserDriver Driver { get { return _driver; } }

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
		/// <see cref="Page{T}(T)"/> constructor
		/// </summary>
		public void Open()
		{
			_driver.Open(GetUrl());
		}

		/// <summary>
		/// Gets whether this page is the currently open page in the browser.
		/// </summary>
		public bool IsCurrent
		{
			get 
			{
				return string.Compare(_driver.GetCurrentRelativeUrl(), GetUrl(), true) == 0;
			}
		}
	}

	/// <summary>
	/// Base class for creating specialized page control classes for controlling
	/// and validating the behaviour of a specific page in the system. This is
	/// a concrete type of the generic <see cref="Page{T}"/> parameterized
	/// </summary>
	/// <remarks>
	/// For each page in the system, you should create a specialization of the
	/// <see cref="Page{T}"/> class, with properties corresponding to the input
	/// fields, buttons, etc. that you wish to control
	/// </remarks>
	public abstract class Page : Page<IBrowserDriver>
	{
		/// <summary>
		/// Creates a new <see cref="Page"/> instance
		/// </summary>
		/// <param name="driver"></param>
		protected Page(IBrowserDriver driver) : base(driver)
		{ }
	}
}
