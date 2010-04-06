using Moq;
using NUnit.Framework;
using Selenium;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class SeleniumDriverTest
	{
        private Mock<ISelenium> _seleniumMock;
        private SeleniumDriver _seleniumDriver;

        [SetUp]
        public void Setup()
        {
			_seleniumMock = new Mock<ISelenium>();
			_seleniumDriver = new SeleniumDriver(_seleniumMock.Object);           
        }

		[Test]
		public void Open()
		{
			// Setup
			const string url = "url";
			_seleniumMock.Setup(x => x.Open(url));

			// Excercise
			_seleniumDriver.Open(url);

			// Validate
			_seleniumMock.VerifyAll();
		}

        [Test]
        public void DisposeSeleniumDriverCallsStop()
        {
            _seleniumMock.Setup(x => x.Stop());

            // Exercise
            _seleniumDriver.Dispose();

            // Validate
            _seleniumMock.VerifyAll();
        }
	}
}
