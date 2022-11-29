using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWebDeiver
{
    internal class WayofWadeHomePage :IDisposable
    {
        private const string URL = "https://www.wayofwade.com/";
        private int sleepMill = 500;
        private readonly By _closeButton = By.CssSelector("#shopify-section-header_banner > div > div > div > div:nth-child(4)");
        private readonly By _searchButton = By.CssSelector("#shopify-section-header_3 > div > div > div > div.col-lg-auto.col-md-4.col-3.tr.col_group_btns > div > a.icon_search.push_side.cb.chp");
        private readonly By _searchInput = By.CssSelector("#nt_search_canvas > div > div.mini_cart_wrap > form > div.frm_search_input.pr.oh > input");
        private readonly By _searchResult = By.CssSelector("#nt_search_canvas > div > div.mini_cart_wrap.atc_opended_rs.atc_show_rs > div.search_header__content.mini_cart_content.fixcl-scroll.widget > div > div.js_prs_search > div > div.col.widget_if_pr > a");

        private IWebDriver _driver;
        public WayofWadeHomePage OpenPage()
        {
            _driver.Navigate().GoToUrl(URL);
            Thread.Sleep(sleepMill);
            try
            {
                _driver.FindElement(_closeButton).Click();
            }
            catch(Exception e)
            {
                Console.WriteLine("-------------Error-------------");
                Console.WriteLine(e.Message);
                Console.WriteLine("-------------------------------");
            }
            finally
            {
                Thread.Sleep(sleepMill);
            }
            return this;

        }
        public string GetSearchResult()
        {
            return _driver.FindElement(_searchResult).Text;
        }
        public WayofWadeHomePage OpenSearchBlock()
        {
            _driver.FindElement(_searchButton).Click();
            Thread.Sleep(2 * sleepMill);
            return this;
        }
        public WayofWadeHomePage WriteTextToArea(string text)
        {
            _driver.FindElement(_searchInput).SendKeys(text);
            Thread.Sleep(5 * sleepMill);
            return this;
        }
        public WayofWadeHomePage()
        {
            _driver = new ChromeDriver(@"C:\BSTU\3k\drivers\chromedriver.exe");
        }
        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
