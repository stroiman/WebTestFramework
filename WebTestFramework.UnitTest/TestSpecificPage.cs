using System;

namespace WebTestFramework.UnitTest
{
	/// <summary>
	/// Specialization of the <see cref="Page{T}"/> class that can be created
	/// in unit tests, because the page class is abstract, it cannot be created.
	/// </summary>
	public class TestSpecificPage : Page<IBrowserDriver>
	{
		public TestSpecificPage(IBrowserDriver driver) : base(driver)
		{
		}

		public override string GetUrl()
		{
			throw new NotImplementedException();
		}
	}
}
