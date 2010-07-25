using System;
using com.gargoylesoftware.htmlunit.html;

namespace WebTestFramework.HtmlUnit
{
	internal class HtmlUnitButton : IButton
	{
		private readonly Func<HtmlElement> _getElementFunc;

		public HtmlUnitButton(Func<HtmlElement> getElementFunc)
		{
			_getElementFunc = getElementFunc;
		}

		public void Click()
		{
			_getElementFunc().click();
		}

		public void ClickAndWait()
		{
			Click();
		}
	}
}