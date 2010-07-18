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

		private HtmlSubmitInput Button
		{
			get
			{
				var button = _driver.CurrentPage.getElementById(_id);
				return (HtmlSubmitInput)button;
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