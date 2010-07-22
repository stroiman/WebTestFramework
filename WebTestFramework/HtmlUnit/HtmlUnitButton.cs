using com.gargoylesoftware.htmlunit.html;

namespace WebTestFramework.HtmlUnit
{
	internal class HtmlUnitButton : IButton
	{
		private HtmlUnitDriver _driver;
		private string _id;

		public HtmlUnitButton(HtmlUnitDriver driver, string id)
		{
			_driver = driver;
			_id = id;
		}

		private HtmlElement Button
		{
			get
			{
				return _driver.CurrentPage.getElementById(_id);
			}
		}

		public void Click()
		{
			Button.click();
		}

		public void ClickAndWait()
		{
			Click();
		}
	}
}