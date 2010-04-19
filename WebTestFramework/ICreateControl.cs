namespace WebTestFramework
{
	/// <summary>
	/// Interface for creating a controls for various locator strategies
	/// </summary>
	public interface ICreateControl<out T>
	{
		/// <summary>
		/// Creates an instance of <typeparamref name="T"/> for representing a
		/// specific element with a specific ID on the web page.
		/// </summary>
		/// <param name="id">
		/// The ID of the element to control
		/// </param>		
		T FromID(string id);
	}
}