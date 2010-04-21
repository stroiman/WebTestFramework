using System;
using Moq;
using NUnit.Framework;
using Selenium;

namespace WebTestFramework.UnitTest
{
    [TestFixture]
    public class SeleniumButtonTest
    {
        private string _controlID;
        private string _controlLocator;
        private Mock<ISelenium> _seleniumMock;
        private SeleniumDriver _driver;
        private IButton _button;

        [SetUp]
        public void Setup()
        {
            _controlID = "submitButton";
            _controlLocator = "id=" + _controlID;
            _seleniumMock = new Mock<ISelenium>(MockBehavior.Strict);
            _driver = new SeleniumDriver(_seleniumMock.Object);
            _button = _driver.CreateButton(_controlID);
        }

        [Test]
        public void ClickCallsSeleniumClick()
        {
            // Setup
            _seleniumMock.Setup(x => x.Click(_controlLocator));

            // Excercise
            _button.Click();

            // Validate
            _seleniumMock.Verify();
        }

        [Test]
        public void ClickAndWait()
        {
            // Setup
            _seleniumMock.Setup(x => x.Click(_controlLocator));
            _seleniumMock.Setup(x => x.WaitForPageToLoad(It.IsAny<string>()));

            // Exercise
            _button.ClickAndWait();

            // Validate
            _seleniumMock.VerifyAll();
        }
    }

	[TestFixture]
	public class CreateSeleniumButtonTest
	{
		private  Mock<ISelenium> _seleniumMock;
		private  SeleniumDriver _driver;

		[SetUp]
		public void Setup()
		{
			_seleniumMock = new Mock<ISelenium>(MockBehavior.Strict);
			_driver = new SeleniumDriver(_seleniumMock.Object);
		}

		private void AssertLocatorIs(IButton button, string expectedLocator)
		{
			if (expectedLocator == null) throw new ArgumentNullException("expectedLocator");
			string actualLocator = null;
			_seleniumMock
				.Setup(x => x.Click(It.IsAny<string>()))
				.Callback<string>(s => actualLocator = s);
			button.Click();
			Assert.That(actualLocator, Is.Not.Null, "Guard");
			Assert.That(actualLocator, Is.EqualTo(expectedLocator));
		}

		[Test]
		public void CreateFromIDDirect()
		{
			var button = _driver.CreateButton("locator");
			AssertLocatorIs(button, "id=locator");
		}

		[Test]
		public void CreateFromID()
		{
			var button = _driver.CreateButton().FromID("locator");
			AssertLocatorIs(button, "id=locator");
		}

		[Test]
		public void CreateFromName()
		{
			var button = _driver.CreateButton().FromName("locator");
			AssertLocatorIs(button, "name=locator");
		}

		[Test]
		public void CreateFromCSS()
		{
			const string cssSelector = "li:last-child input[name='test']";
			const string expectedLocator = "css=" + cssSelector;
			var button = _driver.CreateButton().FromCSS(cssSelector);
			AssertLocatorIs(button, expectedLocator);
		}
	}
}
