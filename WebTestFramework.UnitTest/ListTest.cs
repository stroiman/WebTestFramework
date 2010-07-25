using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class ListTest : TestBase
	{
private  ListPage _page;
		[SetUp]
		public void Setup()
		{
			_page = new ListPage(Driver);
			_page.Open();
		}

		[Test]
		public void ListContains3Elements()
		{
			Assert.That(_page.Array.Count, Is.EqualTo(3));
		}

		[Test]
		public void Element1ContainsField1()
		{
			var element = _page.Array[0];
			Assert.That(element.Input.Text, Is.EqualTo("field1"));
		}

		[Test]
		public void Element3ContainsField3()
		{
			var element = _page.Array[2];
			Assert.That(element.Input.Text, Is.EqualTo("field3"));
		}
	}
}
