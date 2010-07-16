using NUnit.Framework;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class PageTest : TestBase
	{
		private TestPage1 _page;

		[SetUp]
		public void Setup()
		{
			_page = new TestPage1(Driver);
		}

		[Test]
		public void PageIsCurrentAfterBeingOpened()
		{
			// Exercise
			_page.Open();

			// Validate
			Assert.That(_page.IsCurrent);
		}

		[Test]
		public void PageIsCurrentAfterRedirect()
		{
			// Setup
			var redirectPage = new RedirectToPage1(Driver);

			// Exercise
			redirectPage.Open();

			// Validate
			Assert.That(_page.IsCurrent);
			Assert.That(redirectPage.IsCurrent, Is.False);
		}
	}
}
