//using TestingWebDeiver.Pa
using Newtonsoft.Json.Bson;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections;
using TestingWebDeiver;
using NUnit.Framework;

test5();
[Test]
static void test5()
{
    var pageHandler = new WayofWadeShoesPage();
    pageHandler.OpenPage();
    pageHandler.SelectShoes(1);
    pageHandler.AddToCart();
    pageHandler.WriteNumberAddInput(100);
}