using Moq;
using NUnit.Framework;
using Selenium;

namespace WebTestFramework.UnitTest
{
	public class SeleniumControlTest 
	{
		protected string ControlID { get; private set; }
		protected string ControlLocator { get; private set; }
		protected Mock<ISelenium> SeleniumMock { get; private set; }
		protected SeleniumDriver Driver { get; private set; }

		[SetUp]
		public void SeleniumControlTestSetup()
		{
			ControlID = "control";
			ControlLocator = "id=" + ControlID;
			SeleniumMock = new Mock<ISelenium>(MockBehavior.Strict);
			Driver = new SeleniumDriver(SeleniumMock.Object);
		}
	}
}