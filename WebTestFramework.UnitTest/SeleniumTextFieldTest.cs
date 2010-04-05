using Moq;
using NUnit.Framework;
using Selenium;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class SeleniumTextFieldTest
	{
		private string _controlID;
		private string _controlLocator;

		[SetUp]
		public void Setup()
		{
			_controlID = "textBoxID";
			_controlLocator = "id=" + _controlID;
		}

		[Test]
		public void Type()
		{
			// Setup
			const string value = "value";
			var seleniumMock = new Mock<ISelenium>(MockBehavior.Strict);
			seleniumMock.Setup(x => x.Type(_controlLocator, value));
			var driver = new SeleniumDriver(seleniumMock.Object);
			var textBox = driver.CreateTextField(_controlID);

			// Exercise
			textBox.Type(value);

			// Validate
			seleniumMock.VerifyAll();
		}
	}
}
