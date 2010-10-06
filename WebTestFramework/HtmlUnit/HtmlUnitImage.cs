using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.gargoylesoftware.htmlunit.html;

namespace WebTestFramework.HtmlUnit
{
    public class HtmlUnitImage : IImage
    {
        private readonly Func<HtmlElement> _getElementFunc;

        internal HtmlUnitImage(Func<HtmlElement> getElementFunc)
        {
            _getElementFunc = getElementFunc;
        }

        public HtmlImage Element
        {
            get 
            { 
                var element = _getElementFunc();
                if (element == null)
                    throw new ApplicationException("Could not find element");
                var htmlImage = element as HtmlImage;
                if (htmlImage == null)
                    throw new ApplicationException("Element was not an image");
                return htmlImage;
            }
        }

        public string Src
        {
            get
            {
                return Element.getSrcAttribute();
            }
        }
        public string LocalSrc
        {
            get
            {
                var src = Src;
                if (src.StartsWith("/"))
                    return src;
                return Element.getPage()
                    .getWebResponse()
                    .getRequestSettings()
                    .getUrl()
                    .getPath() + "/" + Src;
            }
        }
    }
}
