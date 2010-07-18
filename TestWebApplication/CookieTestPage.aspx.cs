using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebApplication
{
	public partial class CookieTestPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			var cookie = Request.Cookies["TestCookie"];
			if (cookie != null)
				textField.Text = cookie.Value;
		}

		protected void SaveCookieClick(object sender, EventArgs e)
		{
			var value = textField.Text;
			Response.SetCookie(new HttpCookie("TestCookie", value));
		}
	}
}