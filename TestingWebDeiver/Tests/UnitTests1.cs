using Microsoft.Extensions.Configuration;
using NUnit.Framework.Internal;
using PageObjection;
using TestingWebDeiver.Pages;

namespace TestingWebDeiver.Tests
{
    
    public class Tests
    {
        IConfiguration _configuration;
        Logger logs;
        TextWriter writer;

        
        [SetUp]
        public void SetUp()
        {
            writer = new StringWriter();
            logs = new Logger("Logger", InternalTraceLevel.Info, writer);
            _configuration = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\polza\source\repos\TestingWebDeiver\TestingWebDeiver\appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        [Test]
        [Parallelizable]
        public async Task test1()
        {
                using WayofWadeHomePage pageHandler = new PageFactory();
                string expected = pageHandler
                    .OpenPage()
                    .OpenSearchBlock()
                    .WriteTextToArea($"Shoes Wade 001 {"South Beach"} ")
                    .GetSearchResult();
            logs.Info(expected);
                string actual = pageHandler
                    .OpenPage()
                    .OpenSearchBlock()
                    .WriteTextToArea($"Sneakers Wade 001 {"South Beach"} ")
                    .GetSearchResult();
            logs.Info(actual);
                Assert.AreEqual(expected, actual);
            logs.Info("Тест кейс номер 1 выполнен");
        }
        [Test]
        [Parallelizable]
        public async Task test2()
        {
                using WayofWadeShoesPage pageHandler = new PageFactory();
                var assertHandler = pageHandler
                    .OpenPage()
                    .AddToWishList()
                    .OpenWishList()
                    .IsWishListAdded();
                Assert.IsTrue(assertHandler);
            logs.Info("Тест кейс номер 2 выполнен");

        }
        [Test]
        [Parallelizable]
        public async Task test3()
        {
            using WayofWadeShoesPage pageHandler = new PageFactory();
            var assertHandler = pageHandler
                .OpenPage()
                .AddToWishList()
                .OpenWishList()
                .IsWishListAdded();
            Assert.IsTrue(assertHandler);
            logs.Info("Тест кейс номер 3 выполнен");

        }
        [Test]
        [Parallelizable]
        public async Task test4()
        {
                using WayofWadeShoesPage pageHandler = new PageFactory();
                var assertHandler = pageHandler
                    .OpenPage()
                    .SelectShoes()
                    .AddToCart()
                    .WriteNumberAddInput(100)
                    .IsNotifeShow();
                Assert.IsTrue(assertHandler);
            logs.Info("Тест кейс номер 4 выполнен");
        }
        [Test]
        [Parallelizable]
        public async Task test5()
        {
            using WayofWadeHomePage pageHandler = new PageFactory();
            string searchInput = $"shoes wade 001 {"south beach"} ";
            string expected = pageHandler
                .OpenPage()
                .OpenSearchBlock()
                .WriteTextToArea(searchInput)
                .GetSearchResult();
            logs.Info(expected);
            string actual = pageHandler
                .OpenPage()
                .OpenSearchBlock()
                .WriteTextToArea(searchInput.ToUpper())
                .GetSearchResult();
            logs.Info(actual);
            Assert.AreEqual(expected, actual);
            logs.Info("Тест кейс номер 5 выполнен");
        }
        [Test]
        [Parallelizable]
        public async Task test7()
        {
            using WayofWadeHomePage pageHandler = new PageFactory();
            string expected = pageHandler
                .OpenPage()
                .OpenSearchBlock()
                .WriteTextToArea($"Shoes Wade 001 {"South Beach"} ")
                .GetSearchResult();
            logs.Info(expected);
            string actual = pageHandler
                .OpenPage()
                .OpenSearchBlock()
                .WriteTextToArea($"Wade 001 {"South Beach"} ")
                .GetSearchResult();
            logs.Info(actual);
            Assert.AreEqual(expected, actual);
            logs.Info("Тест кейс номер 7 выполнен");
        }
        [Test]
        [Parallelizable]
        public async Task test8()
        {
            using WayofWadeHomePage pageHandler = new PageFactory();
            string expected = pageHandler
                .OpenPage()
                .OpenSearchBlock()
                .WriteTextToArea($"Buy Wade 001 {"South Beach"} ")
                .GetSearchResult();
            logs.Info(expected);
            string actual = pageHandler
                .OpenPage()
                .OpenSearchBlock()
                .WriteTextToArea($"Wade 001 {"South Beach"} ")
                .GetSearchResult();
            logs.Info(actual);
            Assert.AreEqual(expected, actual);
            logs.Info("Тест кейс номер 8 выполнен");
        }
        [Test]
        [Parallelizable]
        public async Task test9()
        {
            using WayofWadeShoesPage pageHandler = new PageFactory();
            var expected = pageHandler.InputMail().isSubscribed();
            logs.Info(expected.ToString());
            
            Assert.IsTrue(expected);
            logs.Info("Тест кейс номер 9 выполнен");
        }
        [Test]
        [Parallelizable]
        public async Task test10()
        {
            using WayofWadeHomePage pageHandler = new PageFactory();
            string expected = pageHandler
                .OpenPage()
                .OpenSearchBlock()
                .WriteTextToArea($"Shoes Wade 001 {"South Beach"} ")
                .GetSearchResult();
            logs.Info(expected);
            string actual = pageHandler
                .OpenPage()
                .OpenSearchBlock()
                .WriteTextToArea($"Wade 001 {"South Beach"} ")
                .GetSearchResult();
            logs.Info(actual);
            Assert.AreEqual(expected, actual);
            logs.Info("Тест кейс номер 10 выполнен");
        }

    }
}
