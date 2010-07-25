using System;
using System.Linq;

namespace WebTestFramework
{
	/// <summary>
	/// Contains browser driver extension helper functions
	/// </summary>
	public static class BrowserDriverExtensions
	{
		/// <summary>
		/// Creates an <see cref="IButton"/> implementation that can be used to
		/// control a single button on a web page.
		/// </summary>
		/// <param name="driver">
		/// The <see cref="IBrowserDriver"/> to use.
		/// </param>
		/// <param name="id">
		/// The ID attribute of the button on the web page.
		/// </param>
		public static IButton CreateButton(this IBrowserDriver driver, string id)
		{
			return driver.CreateButton().FromID(id);
		}


		/// <summary>
		/// Creates a <see cref="ITextField"/> instance that can be used
		/// to control a single text field on a web page form.
		/// </summary>
		/// <param name="driver">
		/// The <see cref="IBrowserDriver"/> to use.
		/// </param>
		/// <param name="id">
		/// The ID of the text field on the form.
		/// </param>
		public static ITextField CreateTextField(this IBrowserDriver driver, string id)
		{
			return driver.CreateTextField().FromID(id);
		}
	}
}
