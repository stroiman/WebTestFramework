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
		/// The ID of the text field on the form.
		/// </param>
		ITextField CreateTextField(string id);

		void Open(string relativeUrl);
	}
}