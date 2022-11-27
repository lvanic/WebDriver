using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWebDeiver
{
    internal class WayofWadeShoesPage : IDisposable
    {
        private const string URL = "https://www.wayofwade.com/collections/shoes";
        private int sleepMill = 200;
        private static int _shoesIndex = 1;
        private readonly By _closeButton = By.CssSelector("#shopify-section-header_banner > div > div > div > div:nth-child(4)");
        private readonly By _shoesButton = By.CssSelector($"#shopify-section-template--16463303966935__main > div > div:nth-child(2) > div > div.on_list_view_false.products.nt_products_holder.row.fl_center.row_pr_1.cdt_des_1.round_cd_false.nt_cover.ratio1_1.position_8.space_20.nt_default > div:nth-child({_shoesIndex}) > div > div.product-image.pr.oh.lazyloadt4sed > a");
        private readonly By _addToCartButton = By.CssSelector("#cart-form_ppr > div.variations_button.in_flex.column.w__100.buy_qv_false > div.flex.wrap > button");
        private readonly By _addShoesInput = By.CssSelector(@"#miniupdates_43448992727255\:ae36764ea1b37e3d35294c5cd6381ce4");
        private readonly By _addShoesIncrementButton = By.CssSelector("#nt_cart_canvas > form > div.mini_cart_wrap > div.mini_cart_content.fixcl-scroll > div > div.mini_cart_items.js_cat_items.lazyloadt4sed > div > div.mini_cart_info > div.mini_cart_actions > div > div > button.plus.db.cb.pa.pd__0.pr__15.tr.r__0 > i");

        private IWebDriver _driver;
        public WayofWadeShoesPage OpenPage()
        {
            _driver.Navigate().GoToUrl(URL);
            Thread.Sleep(sleepMill);
            try
            {
                _driver.FindElement(_closeButton).Click();
            }
            finally
            {
                Thread.Sleep(sleepMill);
            }
            return this;
        }
        public WayofWadeShoesPage SelectShoes(int index)
        {
            _shoesIndex = index;
            _driver.FindElement(_shoesButton).Click();
            Thread.Sleep(sleepMill);
            return this;
        }
        public WayofWadeShoesPage AddToCart()
        {            
            _driver.FindElement(_addToCartButton).Click();
            Thread.Sleep(5 * sleepMill);
            return this;
        }
        public WayofWadeShoesPage WriteNumberAddInput(int number)
        {
            _driver.FindElement(_addShoesInput).SendKeys(number.ToString());
            Thread.Sleep(sleepMill);
            _driver.FindElement(_addShoesIncrementButton).Click();
            Thread.Sleep(sleepMill);
            return this;
        }
        public WayofWadeShoesPage()
        {
            _driver = new ChromeDriver();
        }
        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}

