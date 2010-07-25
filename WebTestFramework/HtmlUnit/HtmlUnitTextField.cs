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

		public void Type(string value)
		{
			var element = _getElementFunc();
			var textInput = element as HtmlTextInput;
			if (textInput != null)
			{
				textInput.type(value);
				return;
			}
			var textArea = element as HtmlTextArea;
			if (textArea != null)
			{
				textArea.type(value);
				return;
			}
			throw new InvalidOperationException("The element does not accept typing");
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public string Text
		{
			get
			{
				var element = _getElementFunc();
				var textInput = element as HtmlTextInput;
				if (textInput != null)
					return textInput.getValueAttribute();
				var textArea = element as HtmlTextArea;
				if (textArea != null)
					return textArea.getText();
				throw new InvalidOperationException("The element does not accept typing");
			}
		}
	}
}