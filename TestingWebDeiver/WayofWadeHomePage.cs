using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWebDeiver
{
    internal class WayofWadeHomePage
    {
        private const string URL = "https://www.wayofwade.com/";

        private readonly By _syButton = By.XPath("//button[@class='btn -big']");
        private readonly By _mainTextArea = By.XPath("//textarea[@id='postform-text']");
        private readonly By _titleInput = By.XPath("//input[@id='postform-name']");
        private readonly By _tenMinOptions = By.XPath("//li[text()='10 Minutes']");
        private readonly By _listSpan = By.Id(("select2-postform-expiration-container"));
        private readonly By _highlightSpan = By.Id(("/html/body/div[1]/div[2]/div[1]/div[2]/div/form/div[5]/div[1]/div[3]/div/span/span[1]/span/span[1]"));


        private IWebDriver _driver;
        public WayofWadeHomePage openPage()
        {
            _driver.Navigate().GoToUrl(URL);
            return this;

        }
        public WayofWadeHomePage writeTextToArea(string text)
        {
            _driver.FindElement(_mainTextArea).SendKeys(text);
            return this;
        }

        public WayofWadeHomePage writeTitle(string text)
        {
            _driver.FindElement(_titleInput).SendKeys(text);
            return this;
        }
        public WayofWadeHomePage selectOptionsByXPath(string xpath)
        {

            _driver.FindElement(_listSpan).Click();
            _driver.FindElement(By.XPath(xpath)).Click();
            return this;
        }

        public WayofWadeHomePage selectHighlightsByXPath(string xpath)
        {

            _driver.FindElement(_highlightSpan).Click();
            _driver.FindElement(By.XPath(xpath)).Click();
            return this;
        }
        //public WayofWadeHomePage createPaste()
        //{
        //    _driver.FindElement(_sendButton).Click();
        //    return this;
        //}

        public WayofWadeHomePage()
        {
            _driver = new ChromeDriver("C:\\BSTU\\5 sem\\Test\\lab5");
        }
    }
}
