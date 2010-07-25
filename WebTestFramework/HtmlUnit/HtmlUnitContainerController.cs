using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTestFramework.HtmlUnit
{
	public class HtmlUnitContainerController<T> : IContainerController<T>
	{
		private HtmlUnitDriver _driver;
		private string _xpath;
		private readonly Func<ICollectionElementDriver, T> _createElementFunction;

		public HtmlUnitContainerController(HtmlUnitDriver driver, string xpath, Func<ICollectionElementDriver, T> createElementFunction)
		{
			_driver = driver;
			_xpath = xpath;
			_createElementFunction = createElementFunction;
		}

		public int Count
		{
			get 
			{
				var x = _driver.CurrentPage.getByXPath(_xpath);
				return x.size();
			}
		}

		public T this[int index]
		{
			get 
			{
				var driver = new HtmlUnitCollectionElementDriver(_driver, _xpath, index);
				return _createElementFunction(driver);
			}
		}
	}
}
