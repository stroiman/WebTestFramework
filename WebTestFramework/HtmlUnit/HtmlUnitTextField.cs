using System;
using com.gargoylesoftware.htmlunit.html;

namespace WebTestFramework.HtmlUnit
{
	internal class HtmlUnitTextField : ITextField
	{
		private HtmlUnitDriver _driver;
		private string _id;

		public HtmlUnitTextField(HtmlUnitDriver driver, string id)
		{
			_id = id;
			_driver = driver;
		}

		private HtmlInput TextField
		{
			get {
				var page = (HtmlPage)_driver.WebClient.getCurrentWindow().getEnclosedPage();
				return (HtmlInput) page.getElementById(_id); }
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