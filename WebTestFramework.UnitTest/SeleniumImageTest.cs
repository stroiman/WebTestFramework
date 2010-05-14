using NUnit.Framework;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class SeleniumImageTest : SeleniumControlTest
	{
		private IImage _image;

		[SetUp]
		public void Setup()
		{
			_image = Driver.CreateImage().FromID(ControlID);
		}

		[Test]
		public void GetHref()
		{
			// Setup
			const string expected = "/images/image.jpg";
			SeleniumMock.Setup(x => x.GetAttribute(ControlLocator + "@href")).Returns(expected);

			// Exercise
			var actual = _image.Href;

			// Validate
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
