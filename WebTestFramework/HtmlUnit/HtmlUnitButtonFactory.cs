using System;

namespace WebTestFramework.HtmlUnit
{
	internal class HtmlUnitButtonFactory : HtmlElementFactory, ICreateControl<IButton>
	{
		public HtmlUnitButtonFactory(HtmlUnitDriver driver) : base(driver)
		{}

		public IButton FromID(string id)
		{
			return new HtmlUnitButton(ElementFromID(id));
		}

		public IButton FromName(string name)
		{
			throw new NotImplementedException();
		}

		public IButton FromXPath(string xpath)
		{
			throw new NotImplementedException();
		}
	}
}