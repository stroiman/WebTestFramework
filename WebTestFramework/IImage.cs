namespace WebTestFramework
{
	/// <summary>
	/// Represents an img-tag on a web page
	/// </summary>
	public interface IImage
	{
		/// <summary>
		/// Gets the HREF attribute from img-tag on the web page.
		/// </summary>
		string Href { get; }
	}
}
