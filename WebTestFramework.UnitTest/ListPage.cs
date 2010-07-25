using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTestFramework.UnitTest
{
	public class ListArray 
	{
		private readonly ICollectionElementDriver _driver;
		public readonly ITextField Input;

		public ListArray(ICollectionElementDriver driver)
		{
			_driver = driver;
			Input = driver.CreateTextField("input");
		}

	}

	public class ListPage : Page
	{
		public readonly IContainerController<ListArray> Array;

		public ListPage(IBrowserDriver driver) : base(driver)
		{
			Array = driver.CreateArray("//ul/li", x => new ListArray(x));
		}

		public override string GetUrl()
		{
			return "/ListPage.aspx";
		}
	}
}
