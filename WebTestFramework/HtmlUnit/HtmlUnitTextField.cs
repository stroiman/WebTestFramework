using System;
using com.gargoylesoftware.htmlunit.html;

namespace WebTestFramework.HtmlUnit
{
	internal class HtmlUnitTextField : ITextField
	{
		private readonly Func<HtmlElement> _getElementFunc;

		public HtmlUnitTextField(Func<HtmlElement> getElementFunc)
		{
			_getElementFunc = getElementFunc;
		}

		private HtmlInput TextField
		{
			get 
			{
				return (HtmlInput)_getElementFunc();
			}
		}

		public void Type(string value)
		{
			TextField.type(value);
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public string Text
		{
			get { return TextField.getValueAttribute(); }
		}
	}
}