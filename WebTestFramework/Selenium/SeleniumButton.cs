using Selenium;

namespace WebTestFramework.Selenium
{
    /// <summary>
    /// A class that uses Selenium RC to control a button on a web page
    /// </summary>
    public class SeleniumButton : SeleniumControlBase, IButton
    {
        /// <summary>
        /// Creates a new <see cref="SeleniumButton"/> instance
        /// </summary>
        /// <param name="selenium">
        /// A reference to the <see cref="ISelenium"/> implementation to use
        /// </param>
        /// <param name="locator">
        /// The selenium locator for this button
        /// </param>
        public SeleniumButton(ISelenium selenium, string locator)
			: base(selenium, locator)
        {
        }

        /// <summary>
        /// Clicks the button. This function returns immediately, any form
        /// posts that the click initiates will occur in the background.
        /// </summary>
        public virtual void Click()
        {
            Selenium.Click(Locator);
        }

        /// <summary>
        /// Clicks the button and wait for a form post to complete. This only
        /// work with normal form posts. Asynchronous or AJAX form posts are
        /// not supported by this implementation.
        /// </summary>
		public virtual void ClickAndWait()
        {
            Click();
            Selenium.WaitForPageToLoad(SeleniumDriver.DefaultTimeout.ToString());
        }
    }
}