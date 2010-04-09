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
		private Mock<ISelenium> _seleniumMock;
		private SeleniumDriver _driver;
		private ITextField _textBox;

		[SetUp]
		public void Setup()
		{
			_controlID = "textBoxID";
			_controlLocator = "id=" + _controlID;
			_seleniumMock = new Mock<ISelenium>(MockBehavior.Strict);
			_driver = new SeleniumDriver(_seleniumMock.Object);
			_textBox = _driver.CreateTextField(_controlID);
		}

		[Test]
		public void Type()
		{
			// Setup
			const string value = "value";
			_seleniumMock.Setup(x => x.Type(_controlLocator, value));

			// Exercise
			_textBox.Type(value);

			// Validate
			_seleniumMock.VerifyAll();
		}

		[Test]
		public void Clear()
		{
			// Setup
			_seleniumMock.Setup(x => x.Type(_controlLocator, ""));

			// Exercise
			_textBox.Clear();

			// Validate
			_seleniumMock.VerifyAll();
		}
	}
}
