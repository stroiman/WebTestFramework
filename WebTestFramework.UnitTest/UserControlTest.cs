using Moq;
using NUnit.Framework;
using Selenium;
using WebTestFramework.Selenium;

namespace WebTestFramework.UnitTest
{
	public class PageUsingUserControl : Page
	{
		public readonly ActualControl Control;

		public PageUsingUserControl(IBrowserDriver driver) : base(driver)
		{
			Control = new ActualControl(driver);
		}

		public override string GetUrl()
		{
			return null;
		}
	}

	public class ActualControl : UserControl
	{
		public readonly ITextField TextField;

		public ActualControl(IBrowserDriver driver) : base(driver)
		{
			TextField = driver.CreateTextField().FromID("field");
		}
	}

	[TestFixture]
	public class UserControlTest
	{
		[Test]
		public void TestUserControl()
		{
			// Setup
			var seleniumMock = new Mock<ISelenium>();
			var driver = new SeleniumDriver(seleniumMock.Object);
			var page = new PageUsingUserControl(driver);
			var value = "text";
			var expectedSeleniumLocator = "id=field";

			// Exercise
			page.Control.TextField.Type(value);

			// Validate
			seleniumMock.Verify(x => x.Type(expectedSeleniumLocator, value));
		}
	}
}
