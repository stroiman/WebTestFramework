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
}
