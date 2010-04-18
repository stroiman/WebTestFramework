namespace WebTestFramework
{
	/// <summary>
	/// Interface for a class that is used to control a single text field
	/// on a web page form.
	/// </summary>
	public interface ITextField
	{
		/// <summary>
		/// Types text in the text field. If text already exists in the field, it
		/// will be cleared.
		/// </summary>
		/// <param name="value">
		/// The text to type in the text field
		/// </param>
		void Type(string value);

		/// <summary>
		/// Clears the content of the text field.
		/// </summary>
		void Clear();
	}
}