using System;

namespace WebTestFramework.HtmlUnit
{
	internal class HtmlUnitButtonFactory : ICreateControl<IButton>
	{
		private HtmlUnitDriver _driver;
		public HtmlUnitButtonFactory(HtmlUnitDriver driver)
		{
			_driver = driver;
		}

		public IButton FromID(string id)
		{
			return new HtmlUnitButton(_driver, id);
		}

		public IButton FromCss(string css)
		{
			throw new NotImplementedException();
		}

		public IButton FromName(string name)
		{
			throw new NotImplementedException();
		}
	}
}