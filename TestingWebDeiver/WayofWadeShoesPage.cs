﻿using OpenQA.Selenium;
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
        private readonly By _closeButton = By.CssSelector("#shopify-section-header_banner > div > div > div > div:nth-child(4)");
        private readonly By _shoesButton = By.CssSelector("#shopify-section-template--16463303966935__main > div > div:nth-child(2) > div > div.on_list_view_false.products.nt_products_holder.row.fl_center.row_pr_1.cdt_des_1.round_cd_false.nt_cover.ratio1_1.position_8.space_20.nt_default > div:nth-child(1) > div > div.product-image.pr.oh.lazyloadt4sed > a");
        private readonly By _addToCartButton = By.CssSelector("#cart-form_ppr > div.variations_button.in_flex.column.w__100.buy_qv_false > div.flex.wrap > button");
        private readonly By _addShoesInput = By.CssSelector(@"#miniupdates_43448992727255\:ae36764ea1b37e3d35294c5cd6381ce4");
        private readonly By _addShoesIncrementButton = By.CssSelector("#nt_cart_canvas > form > div.mini_cart_wrap > div.mini_cart_content.fixcl-scroll > div > div.mini_cart_items.js_cat_items.lazyloadt4sed > div > div.mini_cart_info > div.mini_cart_actions > div > div > button.plus.db.cb.pa.pd__0.pr__15.tr.r__0 > i");
        private readonly By _notifyBlock = By.CssSelector("#sp_notices_wrapper > p");
        private readonly By _addWishListButton = By.CssSelector("#shopify-section-template--16463303966935__main > div > div:nth-child(2) > div > div.on_list_view_false.products.nt_products_holder.row.fl_center.row_pr_1.cdt_des_1.round_cd_false.nt_cover.ratio1_1.position_8.space_20.nt_default > div:nth-child(1) > div > div.product-image.pr.oh.lazyloadt4sed > div.nt_add_w.ts__03.pa");
        private readonly By _wishListButton = By.CssSelector("#shopify-section-header_3 > div > div > div > div.col-lg-auto.col-md-4.col-3.tr.col_group_btns > div > a.icon_like.cb.chp.pr.dn.db_md.js_link_wis");
        private readonly By _wishItemDiv = By.CssSelector("#shopify-section-wishlist_page > div > div.row > div > div.on_list_view_false.products.prs_wis.nt_products_holder.row.fl_center.row_pr_1.cdt_des_1.round_cd_false.nt_cover.ratio_nt.position_8.space_30.nt_default > div:nth-child(1)");
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
        public bool IsWishListAdded()
        {
            try
            {
                _driver.FindElement(_wishItemDiv);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public WayofWadeShoesPage OpenWishList()
        {
            _driver.FindElement(_wishListButton).Click();
            Thread.Sleep(5 * sleepMill);
            return this;
        }
        public WayofWadeShoesPage AddToWishList()
        {
            _driver.FindElement(_addWishListButton).Click();
            Thread.Sleep(sleepMill);
            return this;
        }
        public WayofWadeShoesPage SelectShoes()
        {
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
            _driver = new ChromeDriver(@"C:\BSTU\3k\drivers\chromedriver.exe");
        }
        public bool IsNotifeShow()
        {
            var zIndex = Convert.ToInt32(_driver.FindElement(_notifyBlock).GetCssValue("z-index"));
            return zIndex > 60000;
        }
        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}

