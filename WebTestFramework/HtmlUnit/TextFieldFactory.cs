using System;

namespace WebTestFramework.HtmlUnit
{
	internal class TextFieldFactory : HtmlElementFactory, ICreateControl<ITextField>
	{
		public TextFieldFactory(HtmlUnitDriver driver) : base(driver)
		{}

		public ITextField FromID(string id)
		{
			return new HtmlUnitTextField(ElementFromID(id));
		}

		public ITextField FromCss(string css)
		{
			throw new NotImplementedException();
		}

		public ITextField FromName(string name)
		{
			throw new NotImplementedException();
		}

		public ITextField FromXPath(string xpath)
		{
			return new HtmlUnitTextField(ElementFromXPath(xpath));
		}
	}
}