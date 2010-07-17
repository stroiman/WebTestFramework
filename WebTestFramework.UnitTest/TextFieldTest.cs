using System;
using Moq;
using NUnit.Framework;
using Selenium;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class TextFieldTest : TestBase
	{
		TestPage1 _page;

		[SetUp]
		public void Setup()
		{
			_page = new TestPage1(Driver);
			_page.Open();
		}

		[Test]
		public void Type()
		{
			_page.InputField.Type("expected");
			_page.Button.ClickAndWait();
			var actual = _page.OutputField.Text;
			Assert.That(actual, Is.EqualTo("expected"));
		}

		[Test]
		public void Clear()
		{
			_page.InputField.Type("something");
			_page.InputField.Clear();
			_page.Button.ClickAndWait();
			var actual = _page.OutputField.Text;
			Assert.That(actual, Is.EqualTo(""));
		}
	}
}
