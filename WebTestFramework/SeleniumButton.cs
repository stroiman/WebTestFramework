using Selenium;

namespace WebTestFramework
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
        /// <param name="id">
        /// The ID attribute of the button
        /// </param>
        public SeleniumButton(ISelenium selenium, string id)
            : base(selenium, id)
        {
        }

        /// <summary>
        /// Clicks the button. This function returns immediately, any form
        /// posts that the click initiates will occur in the background.
        /// </summary>
        public void Click()
        {
            Selenium.Click(Locator);
        }

        /// <summary>
        /// Clicks the button and wait for a form post to complete. This only
        /// work with normal form posts. Asynchronous or AJAX form posts are
        /// not supported by this implementation.
        /// </summary>
        public void ClickAndWait()
        {
            Click();
            Selenium.WaitForPageToLoad(SeleniumDriver.DefaultTimeout.ToString());
        }
    }
}