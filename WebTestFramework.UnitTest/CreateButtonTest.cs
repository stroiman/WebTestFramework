using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class CreateButtonTest : TestBase
	{
		private const string Expectedvalue = "expectedValue";
		private TestPage1 _page;

		[SetUp]
		public void Setup()
		{
			_page = new TestPage1(Driver);
			_page.Open();
			_page.InputField.Type(Expectedvalue);
		}

		[TearDown]
		public void Teardown()
		{
			Assert.That(_page.OutputField.Text, Is.EqualTo(Expectedvalue));
		}

		[Test]
		public void CreateButtonFromID()
		{
			var button = Driver.CreateButton().FromID("UpdateButton");
			button.ClickAndWait();
		}

		[Test]
		public void CreateButtonFromCss()
		{
			var button = Driver.CreateButton().FromCss("input[@type='submit']");
			button.ClickAndWait();
		}
	}
}
