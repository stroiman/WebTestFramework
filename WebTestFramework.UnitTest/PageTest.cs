using Moq;
using NUnit.Framework;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class PageTest
	{
		private string _id;

		[SetUp]
		public void Setup()
		{
			_id = "textFieldID";
		}

		[Test]
		public void CreateTextField()
		{
			// Setup
			var driverMock = new Mock<IBrowserDriver>();
			var dummyTextField = new Mock<ITextField>().Object;
			driverMock.Setup(x => x.CreateTextField(_id)).Returns(dummyTextField);
			var page = new TestSpecificPage(driverMock.Object);

			// Exercise
			var actual = page.CreateTextField(_id);

			// Validate
			Assert.That(actual, Is.SameAs(dummyTextField));
		}

		[Test]
		public void OpenPage()
		{
			// Setup
			const string url = "/home";
			var driverMock = new Mock<IBrowserDriver>(MockBehavior.Strict);
			var pageMock = new Mock<Page>(driverMock.Object);
			pageMock.Setup(x => x.GetUrl()).Returns(url);
			driverMock.Setup(x => x.Open(url));

			// Exercise
			pageMock.Object.Open();

			// Validate
			driverMock.VerifyAll();
		}
	}
}
