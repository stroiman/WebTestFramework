using System;
using com.gargoylesoftware.htmlunit.html;

namespace WebTestFramework.HtmlUnit
{
    public class HtmlElementFactory
	{
		public HtmlElementFactory(HtmlUnitDriver driver)
		{
			_driver = driver;
		}

		private HtmlUnitDriver _driver;

		protected Func<HtmlElement> ElementFromID(string id)
		{
			return () => _driver.CurrentPage.getElementById(id);
		}

		protected Func<HtmlElement> ElementFromXPath(string xpath)
		{
			return () => (HtmlElement)_driver.CurrentPage.getFirstByXPath(xpath);
		}
	}

    public class HtmlElementFactory<T> : HtmlElementFactory, ICreateControl<T>
    {
        private readonly Func<Func<HtmlElement>, T> _createElementDriver;

        public HtmlElementFactory(
            HtmlUnitDriver driver,
            Func<Func<HtmlElement>, T> createElementDriver)
            : base(driver)
        {
            _createElementDriver = createElementDriver;
        }

        public T FromID(string id)
        {
            return _createElementDriver(ElementFromID(id));
        }

        public T FromName(string name)
        {
            throw new NotImplementedException();
        }

        public T FromXPath(string xpath)
        {
            throw new NotImplementedException();
        }
    }
}