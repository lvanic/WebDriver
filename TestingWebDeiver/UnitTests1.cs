using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWebDeiver
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void test1()
        {
            using var pageHandler = new WayofWadeHomePage();
            pageHandler.OpenPage();
            pageHandler.OpenSearchBlock();
            pageHandler.WriteTextToArea($"Shoes Wade 001 {"South Beach"} ");
            string expected = pageHandler.GetSearchResult();

            pageHandler.OpenPage();
            pageHandler.OpenSearchBlock();
            pageHandler.WriteTextToArea($"Sneakers Wade 001 {"South Beach"} ");
            string actual = pageHandler.GetSearchResult();

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void test4()
        {
            using var pageHandler = new WayofWadeShoesPage();
            pageHandler.OpenPage();
            pageHandler.SelectShoes();
            pageHandler.AddToCart();
            pageHandler.WriteNumberAddInput(100);
            var assertHandler = pageHandler.IsNotifeShow();
            Assert.IsTrue(assertHandler);
        }
        
    }
}
