using Selenium;

namespace WebTestFramework
{
    /// <summary>
    /// Base class for selenium controller classes
    /// </summary>
    public class SeleniumControlBase
    {
        private readonly ISelenium _selenium;
        private readonly string _id;        

        /// <summary>
        /// Creates a new <see cref="SeleniumControlBase"/> instance.
		/// </summary>
		/// <param name="selenium">
		/// A reference to the <see cref="ISelenium"/> implementation to use
		/// </param>
		/// <param name="id">
		/// The ID attribute of the control
		/// </param>
		protected SeleniumControlBase(ISelenium selenium, string id)
        {
            _selenium = selenium;
            _id = id;
        }

        /// <summary>
        /// Gets a reference to the <see cref="ISelenium"/> instance 
        /// implementing the Selenium RC
        /// </summary>
        protected ISelenium Selenium { get { return _selenium; } }

        /// <summary>
        /// Gets the selenium locator
        /// </summary>
        protected string Locator { get { return "id=" + _id; } }
    }


    /// <summary>
	/// A class that uses Selenium RC to control a text field on a web page form.
	/// </summary>
	public class SeleniumTextField : SeleniumControlBase, ITextField
	{
        /// <summary>
		/// Creates a new <see cref="SeleniumTextField"/> instance.
		/// </summary>
		/// <param name="selenium">
		/// A reference to the <see cref="ISelenium"/> implementation to use
		/// </param>
		/// <param name="id">
		/// The ID attribute of the text field to control
		/// </param>
		internal SeleniumTextField(ISelenium selenium, string id)
            : base(selenium, id)
		{
		}

        /// <summary>
		/// Types text in the text field. If text already exists in the field, it
		/// will be cleared.
		/// </summary>
		/// <param name="value">
		/// The text to type in the text field
		/// </param>
		public virtual void Type(string value)
		{
			Selenium.Type(Locator, value);
		}

		/// <summary>
		/// Clears the content of the text field.
		/// </summary>
		public virtual void Clear()
		{
			Type("");
		}
	}
}
