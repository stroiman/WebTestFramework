namespace WebTestFramework
{
	public class UserControl<TBrowserDriver> where TBrowserDriver : IBrowserDriver
	{
		private readonly TBrowserDriver _driver;

		/// <summary>
		/// Creates a new <see cref="Page{T}"/> instance
		/// </summary>
		/// <param name="driver">
		/// A reference to th <see cref="IBrowserDriver"/> implementation used to 
		/// control the browser.
		/// </param>
		protected UserControl(TBrowserDriver driver)
		{
			_driver = driver;
		}

		/// <summary>
		/// Gets a reference to the <see cref="IBrowserDriver"/> specialization
		/// used when constructing this instance.
		/// </summary>
		public TBrowserDriver Driver { get { return _driver; } }
	}

	public class UserControl : UserControl<IBrowserDriver> {
		protected UserControl(IBrowserDriver driver) : base(driver)
		{}
	}
}