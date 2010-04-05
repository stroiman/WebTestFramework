using Selenium;

namespace WebTestFramework
{
	/// <summary>
	/// A class that uses Selenium RC to control a text field on a web page form.
	/// </summary>
	public class SeleniumTextField
	{
		private readonly ISelenium _selenium;
		private readonly string _controlID;

		/// <summary>
		/// Creates a new <see cref="SeleniumTextField"/> instance.
		/// </summary>
		/// <param name="selenium">
		/// A reference to the <see cref="ISelenium"/> implementation to use
		/// </param>
		/// <param name="controlID">
		/// The ID of the text field to control
		/// </param>
		public SeleniumTextField(ISelenium selenium, string controlID)
		{
			_selenium = selenium;
			_controlID = controlID;
		}

		private string Locator { get { return "id=" + _controlID; } }

		/// <summary>
		/// Types text in the text field. If text already exists in the field, it
		/// will be cleared.
		/// </summary>
		/// <param name="value">
		/// The text to type in the text field
		/// </param>
		public void Type(string value)
		{
			_selenium.Type(Locator, value);
		}
	}
}
