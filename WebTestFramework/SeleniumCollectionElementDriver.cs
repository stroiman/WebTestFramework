using System;

namespace WebTestFramework
{
	/// <summary>
	/// Selenium specific implementation of the <see cref="ICollectionElementDriver"/>
	/// </summary>
	public class SeleniumCollectionElementDriver : ICollectionElementDriver
	{
		private readonly SeleniumDriver _seleniumDriver;
		private readonly string _xpath;
		private readonly int _index;

		/// <summary>
		/// Creates a new <see cref="SeleniumCollectionElementDriver"/> instance
		/// </summary>
		public SeleniumCollectionElementDriver(SeleniumDriver seleniumDriver, string xpath, int index)
		{
			_seleniumDriver = seleniumDriver;
			_xpath = xpath;
			_index = index;
		}

		private string GetLocator(string localXPath)
		{
			return string.Format("xpath={0}[{1}]{2}", _xpath, _index + 1, localXPath);
		}

		/// <summary>
		/// Implements <see cref="ICollectionElementDriver.CreateTextField"/>
		/// </summary>
		public ITextField CreateTextField(string localXPath)
		{
			return _seleniumDriver.CreateTextFieldControl(GetLocator(localXPath));
		}

		/// <summary>
		/// Implements <see cref="ICollectionElementDriver.CreateButton"/>
		/// </summary>
		/// <param name="localXPath"></param>
		public IButton CreateButton(string localXPath)
		{
			return _seleniumDriver.CreateButtonControl(GetLocator(localXPath));
		}

		/// <summary>
		/// Creates a controller for a specific radio button inside a collection element
		/// </summary>
		/// <param name="localXPath">
		/// The xpath to identify the element, local to the container element xpath.
		/// </param>
		/// <returns>
		/// An <see cref="IRadioButton"/> implementation that can be used to control this radio button
		/// </returns>
		public IRadioButton CreateRadioButton(string localXPath)
		{
			return _seleniumDriver.CreateRadioButtonControl(GetLocator(localXPath));
		}
	}
}