using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace WebTestFramework.UnitTest
{
	[TestFixture]
	public class ImageTest : TestBase
	{
		private PageWithImages _page;

		[SetUp]
		public void Setup()
		{
			_page = new PageWithImages(Driver);
			_page.Open();
		}

		[Test]
		public void CheckUrlOfImageWithAbsolutePath()
		{
			var image = _page.ImageWithAbsolutePath;
            Assert.That(image.Src, Is.EqualTo("/image.jpg"));
			Assert.That(image.LocalSrc, Is.EqualTo("/image.jpg"));
		}

		[Test]
		public void CheckUrlOfImageWithRelativePath()
		{
			var image = _page.ImageWithRelativePath;
            Assert.That(image.Src, Is.EqualTo("image.jpg"));
			Assert.That(image.LocalSrc, Is.EqualTo("/image.jpg"));
		}
	}
}
