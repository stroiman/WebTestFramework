namespace WebTestFramework
{
	/// <summary>
	/// Interface for a class that controls the browser
	/// </summary>
	public interface IBrowserDriver
	{
		/// <summary>
		/// Creates an <see cref="ITextField"/> implementation that can be used
		/// to control a single text field on a web page form.
		/// </summary>
		/// <param name="id">
        /// The ID attribute of the text field on the form.
		/// </param>
		ITextField CreateTextField(string id);

        /// <summary>
        /// Creates an <see cref="IButton"/> implementation that can be used to
        /// control a single button on a web page.
        /// </summary>
        /// <param name="id">
        /// The ID attribute of the button on the web page.
        /// </param>
        IButton CreateButton(string id);

		/// <summary>
		/// Creates an <see cref="ICreateControl{T}"/> for creating an
		/// <see cref="IButton"/> implementation
		/// </summary>
		ICreateControl<IButton> CreateButton();

        /// <summary>
        /// Opens a url in the browser. The url is relative to the root of the
        /// web application being tested.
        /// </summary>
        /// <param name="relativeUrl">
        /// The relative URL to open.
        /// </param>
		void Open(string relativeUrl);

		/// <summary>
		/// Gets the value of a cookie in the browser
		/// </summary>
		/// <param name="cookieName">
		/// The name of the cookie.
		/// </param>
		/// <returns>
		/// The value of the cookie, if it exists; otherwise <c>null</c>
		/// </returns>
		string GetCookie(string cookieName);

		/// <summary>
		/// Gets the URL that is currently open in the browser.
		/// </summary>
		/// <returns>
		/// A url relative to the root of the application
		/// </returns>
		string GetCurrentRelativeUrl();

		/// <summary>
		/// Deletes a cookie in the browser
		/// </summary>		
		/// <param name="cookieName">
		/// The name of the cookie to delete
		/// </param>
		void DeleteCookie(string cookieName);

		/// <summary>
		/// Creates a cookie in the browser
		/// </summary>
		/// <param name="cookieName">
		/// The name of the cookie
		/// </param>
		/// <param name="value">
		/// The value of the cookie
		/// </param>
		void CreateCookie(string cookieName, string value);

		/// <summary>
		/// Gets whether or not a specific text appears on the current page
		/// </summary>
		/// <param name="text">
		/// The text to search for
		/// </param>
		/// <returns>
		/// <c>true</c> if the text was found; otherwise <c>false</c>
		/// </returns>
		bool IsTextPresent(string text);
	}
}