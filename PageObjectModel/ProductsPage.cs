using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace c__basic_SD5858_VoThiBeThi_section1.PageObjectModel
{
    internal class ProductsPage
    {
        IWebDriver driver;
        WebDriverWait wait;
        Actions actions;

        By productsBtn = By.XPath("//a[contains(text(), ' Products')]");
        By addProductBtn = By.CssSelector(".add-to-cart");
        By productList = By.CssSelector("div.product-image-wrapper");
        By productDesc = By.CssSelector(".product-overlay .overlay-content p"); // Product description
        By productPrice = By.CssSelector(".product-overlay .overlay-content h2"); // Product price
        By continueBtn = By.XPath("//button[contains(text(), 'Continue Shopping')]");

        By cartBtn = By.CssSelector("i.fa-shopping-cart");

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver);
        }

        public void clickProductBtn()
        {
            IWebElement btn = driver.FindElement(productsBtn);
            wait.Until(p => btn.Displayed);
            btn.Click();
        }

        public IList<IWebElement> getProductList()
        {
            IList<IWebElement> list = driver.FindElements(productList);
            wait.Until(p => list.Count > 0);
            return list;
        }

        public void addProductToCart(IWebElement product)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", product);
            Thread.Sleep(500);
            actions.MoveToElement(product).Perform();
            IWebElement button = product.FindElement(addProductBtn);
            wait.Until(p => button.Displayed);
            button.Click();
        }

        public ProductInfo getProductInfor(IWebElement product)
        {
            actions.MoveToElement(product).Perform();
            string description = product.FindElement(productDesc).Text.Trim();
            string priceText = product.FindElement(productPrice).Text;
            var match = Regex.Match(priceText, @"[0-9]+(\.[0-9]+)?");
            double price = match.Success ? Convert.ToDouble(match.Value) : 0;
            return new ProductInfo
            {
                Description = description,
                Price = price,
                Quantity = 1
            };
        }

        public void clickContinueShopping()
        {
            IWebElement button = driver.FindElement(continueBtn);
            wait.Until(btn => button.Displayed);
            button.Click();
        }

        public void clickCartBtn()
        {
            driver.FindElement(cartBtn).Click();
        }
    }
}
