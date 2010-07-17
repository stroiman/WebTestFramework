using System;

namespace WebTestFramework.HtmlUnit
{
	internal class TextFieldFactory : ICreateControl<ITextField>
	{
		private HtmlUnitDriver _driver;

		public TextFieldFactory(HtmlUnitDriver driver)
		{
			_driver = driver;
		}

		public ITextField FromID(string id)
		{
			return new HtmlUnitTextField(_driver, id);
		}

		public ITextField FromCss(string css)
		{
			throw new NotImplementedException();
		}

		public ITextField FromName(string name)
		{
			throw new NotImplementedException();
		}
	}
}