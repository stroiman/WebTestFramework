using System;

namespace WebTestFramework.Selenium
{
	/// <summary>
	/// Selenium specific implementation of the <see cref="IContainerController{T}"/> 
	/// generic interface
	/// </summary>
	public class SeleniumContainerController<T> : IContainerController<T>
	{
		private readonly SeleniumDriver _seleniumDriver;
		private readonly string _xpath;
		private readonly Func<ICollectionElementDriver, T> _createElementFunction;

		/// <summary>
		/// Creates a new <see cref="SeleniumContainerController{T}"/> instance
		/// </summary>
		public SeleniumContainerController(SeleniumDriver seleniumDriver, string xpath, Func<ICollectionElementDriver, T> createElementFunction)
		{
			_seleniumDriver = seleniumDriver;
			_xpath = xpath;
			_createElementFunction = createElementFunction;
		}

		/// <summary>
		/// Gets the number of elements in the collection
		/// </summary>
		public int Count
		{
			get { return (int)_seleniumDriver.Selenium.GetXpathCount(_xpath); }
		}

		/// <summary>
		/// Gets the controller for controlling a specific element in the collection
		/// </summary>
		/// <param name="index">
		/// The index of the element to retrieve. This is the zero-based index, so the interface
		/// follows a c# indexing style
		/// </param>
		/// <remarks>
		/// An implementation of this function does not necessarily throw an 
		/// <see cref="ArgumentOutOfRangeException"/> if the specified index is too high.
		/// This is because that some implementations of this interface, each call take a significant
		/// large amount of time to execute. So the check for the argument to be lower than the
		/// <see cref="IContainerController{T}.Count"/> property is not necessarily implemented.
		/// In this case, you will just get a different exception from the concrete driver that
		/// the element you are trying to access is not present.
		/// </remarks>
		public T this[int index]
		{
			get
			{
				var arrayElementDriver = new SeleniumCollectionElementDriver(_seleniumDriver, _xpath, index);
				return _createElementFunction(arrayElementDriver);
			}
		}
	}
}