using System;
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
			// Setup
            _seleniumMock.Setup(x => x.Stop());

            // Exercise
            _seleniumDriver.Dispose();

            // Validate
            _seleniumMock.VerifyAll();
        }

		[Test]
		public void GetExistingCookie()
		{
			// Setup
			var cookieName = "cookie";
			var expected = "cookieValue";
			_seleniumMock.Setup(x => x.GetCookieByName(cookieName)).Returns(expected);

			// Exercise
			var actual = _seleniumDriver.GetCookie(cookieName);

			// Validate
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void GetNonexistingCookie()
		{
			// Setup
			var cookieName = "cookie";
			_seleniumMock
				.Setup(x => x.GetCookieByName(cookieName))
				.Throws(new SeleniumException());

			// Exercise
			var actual = _seleniumDriver.GetCookie(cookieName);

			// Validate
			Assert.That(actual, Is.Null);
		}
	}
}
