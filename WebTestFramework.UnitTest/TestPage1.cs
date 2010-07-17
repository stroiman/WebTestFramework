using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTestFramework.UnitTest
{
	public class PageWithImages : Page
	{
		public readonly IImage ImageWithAbsolutePath;
		public readonly IImage ImageWithRelativePath;

		public PageWithImages(IBrowserDriver driver) : base(driver)
		{
			ImageWithAbsolutePath = driver.CreateImage().FromID("imageWithAbsolutePath");
			ImageWithRelativePath = driver.CreateImage().FromID("imageWithRelativePath");
		}

		public override string GetUrl()
		{
			return "/PageWithImages.aspx";
		}
	}

	public class TestPage1 : Page
	{
		public readonly ITextField InputField;
		public readonly ITextField OutputField;
		public readonly IButton Button;

		public TestPage1(IBrowserDriver driver) : base(driver)
		{
			InputField = driver.CreateTextField().FromID("TextField");
			OutputField = driver.CreateTextField().FromID("TextFieldOutput");
			Button = driver.CreateButton().FromID("UpdateButton");
		}

		public override string GetUrl()
		{
			return "/TestPage1.aspx";
		}
	}

	public class RedirectToPage1 : Page
	{
		public RedirectToPage1(IBrowserDriver driver) : base(driver)
		{
		}

		public override string GetUrl()
		{
			return "/RedirectToPage1.aspx";
		}
	}
}
