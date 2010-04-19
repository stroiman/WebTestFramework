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
			const string cookieName = "cookie";
			const string expected = "cookieValue";
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
			const string cookieName = "cookie";
			_seleniumMock
				.Setup(x => x.GetCookieByName(cookieName))
				.Throws(new SeleniumException());

			// Exercise
			var actual = _seleniumDriver.GetCookie(cookieName);

			// Validate
			Assert.That(actual, Is.Null);
		}

		[Test]
		public void DeleteCookie()
		{
			// Setup
			const string cookieName = "cookie";
			_seleniumMock.Setup(x => x.DeleteCookie(cookieName, "path=/"));

			// Exercise
			_seleniumDriver.DeleteCookie(cookieName);

			// Validate
			_seleniumMock.VerifyAll();
		}

		[Test]
		public void GetCurrentRelativeUrlTest()
		{
			// Setup
			_seleniumMock.Setup(x => x.GetLocation()).Returns("http://example.com/relative/path");

			// Exercise
			var result = _seleniumDriver.GetCurrentRelativeUrl();

			// Validate
			Assert.That(result, Is.EqualTo("/relative/path"));
		}

		[Test]
		public void CreateCookie()
		{
			// Setup
			const string cookieName = "cookie";
			const string cookieValue = "value";
			_seleniumMock.Setup(x => x.CreateCookie(cookieName + "=" + cookieValue, "path=/"));

			// Exercise
			_seleniumDriver.CreateCookie(cookieName, cookieValue);

			// Validate
			_seleniumMock.VerifyAll();
		}
	}
}
