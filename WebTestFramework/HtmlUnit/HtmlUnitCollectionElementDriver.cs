using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.gargoylesoftware.htmlunit.html;

namespace WebTestFramework.HtmlUnit
{
	class HtmlUnitCollectionElementDriver : ICollectionElementDriver
	{
		private readonly HtmlUnitDriver _driver;
		private readonly string _xpath;
		private readonly int _index;

		public HtmlUnitCollectionElementDriver(HtmlUnitDriver driver, string xpath, int index)
		{
			_driver = driver;
			_xpath = xpath;
			_index = index;
		}

		public ITextField CreateTextField(string localXPath)
		{

			return new HtmlUnitTextField(() =>
				{

					var e = (HtmlElement)_driver.CurrentPage.getByXPath(_xpath).get(_index);
					var child = (HtmlElement)e.getFirstByXPath(localXPath);
					return child;
				}
				);
		}

		public IButton CreateButton(string localXPath)
		{
			return new HtmlUnitButton(() =>
			{
				var e = (HtmlElement)_driver.CurrentPage.getByXPath(localXPath).get(_index);
				var child = (HtmlElement)e.getFirstByXPath(localXPath);
				return child;
			});
		}

		public IRadioButton CreateRadioButton(string localXPath)
		{
			throw new NotImplementedException();
		}
	}
}
