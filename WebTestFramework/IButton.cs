namespace WebTestFramework
{
    /// <summary>
    /// Interface used for manipulating a button on a web page.
    /// </summary>
    public interface IButton
    {
        /// <summary>
        /// Clicks the button. 
        /// </summary>
        void Click();

        /// <summary>
        /// Clicks the button and waits for the page to load, e.g. a form post.
        /// </summary>
        /// <remarks>
        /// The default implementation returned by 
        /// <see cref="IBrowserDriver.CreateButton"/> only supports waiting
        /// during normal form posts, not asynchronous or AJAX posts. 
        /// Specialized implementations could be created however that works
        /// with these types of posts. This can allow you to change the 
        /// behaviour of a single button, replace the button controller in
        /// the test suite, and have all the unit tests working again.
        /// </remarks>
        void ClickAndWait();
    }
}