namespace WebTestFramework
{
	/// <summary>
	/// Represents an img-tag on a web page
	/// </summary>
	public interface IImage
	{
		/// <summary>
		/// Gets the src attribute from img-tag on the web page.
		/// </summary>
		string Src { get; }

		/// <summary>
		/// Gets image src local to the web server, e.g. if the absolute
		/// url is "http://example.com/image.jpg", this property will return
		/// "/image.jpg"
		/// </summary>
		string LocalSrc { get; }
	}
}
