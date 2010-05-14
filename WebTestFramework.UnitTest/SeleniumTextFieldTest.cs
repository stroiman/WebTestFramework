using System;
using Moq;
using NUnit.Framework;
using Selenium;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class SeleniumTextFieldTest : SeleniumControlTest
	{
		private ITextField _textBox;

		[SetUp]
		public void Setup()
		{
			_textBox = Driver.CreateTextField(ControlID);
		}

		[Test]
		public void Type()
		{
			// Setup
			const string value = "value";
			SeleniumMock.Setup(x => x.Type(ControlLocator, value));

			// Exercise
			_textBox.Type(value);

			// Validate
			SeleniumMock.VerifyAll();
		}

		[Test]
		public void Clear()
		{
			// Setup
			SeleniumMock.Setup(x => x.Type(ControlLocator, ""));

			// Exercise
			_textBox.Clear();

			// Validate
			SeleniumMock.VerifyAll();
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
				.Callback<string, string>((s, t) => actualLocator = s);
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

		[Test]
		public void CreateFromName()
		{
			var textField = _driver.CreateTextField().FromName("locator");
			AssertLocatorIs(textField, "name=locator");
		}

		[Test]
		public void CreateFromCss()
		{
			const string cssSelector = "li:last-child input[name='test']";
			const string expectedLocator = "css=" + cssSelector;
			var textField = _driver.CreateTextField().FromCss(cssSelector);
			AssertLocatorIs(textField, expectedLocator);
		}
	}
}
