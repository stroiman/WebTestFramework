using System;
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

	[TestFixture]
	public class CreateTextFieldTest
	{
		private Mock<ISelenium> _seleniumMock;
		private SeleniumDriver _driver;

		[SetUp]
		public void Setup()
		{
			_seleniumMock = new Mock<ISelenium>(MockBehavior.Strict);
			_driver = new SeleniumDriver(_seleniumMock.Object);
		}
		
		private void AssertLocatorIs(ITextField button, string expectedLocator)
		{
			if (expectedLocator == null) throw new ArgumentNullException("expectedLocator");
			string actualLocator = null;
			_seleniumMock
				.Setup(x => x.Type(It.IsAny<string>(), ""))
				.Callback<string, string>((s,t) => actualLocator = s);
			button.Type("");
			Assert.That(actualLocator, Is.Not.Null, "Guard");
			Assert.That(actualLocator, Is.EqualTo(expectedLocator));
		}

		[Test]
		public void CreateFromIDDirect()
		{
			var textField = _driver.CreateTextField("textfield");
			AssertLocatorIs(textField, "id=textfield");
		}

		[Test]
		public void CreateFromID()
		{
			var textField = _driver.CreateTextField().FromID("textfield");
			AssertLocatorIs(textField, "id=textfield");
		}
	}
}
