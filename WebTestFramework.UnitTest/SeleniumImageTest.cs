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
		public void GetSrc()
		{
			// Setup
			const string expected = "/images/image.jpg";
			SeleniumMock.Setup(x => x.GetAttribute(ControlLocator + "@src")).Returns(expected);

			// Exercise
			var actual = _image.Src;

			// Validate
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void GetLocalSrc()
		{
			// Setup
			const string expected = "/images/image.jpg";
			const string absoluteSrc = "http://example.com" + expected;
			SeleniumMock.Setup(x => x.GetAttribute(ControlLocator + "@src")).Returns(
				absoluteSrc);

			// Exercise
			var actual = _image.LocalSrc;

			// Validate
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
