using Moq;
using NUnit.Framework;
using Selenium;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class SeleniumDriverTest
	{
		[Test]
		public void Open()
		{
			// Setup
			const string url = "url";
			var seleniumMock = new Mock<ISelenium>();
			var seleniumDriver = new SeleniumDriver(seleniumMock.Object);
			seleniumMock.Setup(x => x.Open(url));

			// Excercise
			seleniumDriver.Open(url);

			// Validate
			seleniumMock.VerifyAll();
		}
	}
}
