using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Security.Principal;
using OpenQA.Selenium.DevTools.V139.Runtime;

namespace c__basic_SD5858_VoThiBeThi_section1.PageObjectModel
{
    internal class CartPage
    {
        IWebDriver driver;
        WebDriverWait wait;


        By shoppingCartTitle = By.XPath("//li[@class='active' and text()='Shopping Cart']");
        By tableRows = By.Id("#cart_info_table tbody tr");
        By description = By.ClassName(".cart_description");
        By price = By.ClassName(".cart_price");
        By quantity = By.ClassName(".cart_quantity");
        By total = By.ClassName(".cart_total");


        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IList<IWebElement> cartProducts() // Get list of products in cart
        {
            wait.Until(p => driver.FindElement(shoppingCartTitle).Displayed);
            return driver.FindElements(tableRows);
        }

        public string getDesription(IWebElement row)
        {
            return row.FindElement(description).Text.Trim();
        }

        public double getPrice(IWebElement row)
        {
            string priceVal = row.FindElement(price).Text;
            var match = Regex.Match(priceVal, @"[0-9]+(\.[0-9]+)?");
            return match.Success ? Convert.ToDouble(match.Value) : 0;
        }

        public int getQuantity(IWebElement row)
        {
            return int.Parse(row.FindElement(quantity).Text);
        }

        public double getTotal(IWebElement row)
        {
            string totalVal = row.FindElement(total).Text;
            var match = Regex.Match(totalVal, @"[0-9]+(\.[0-9]+)?");
            return match.Success ? Convert.ToDouble(match.Value) : 0;
        }


        public List<ProductInfo> getCartProducts()
        {
            IList<IWebElement> productList = cartProducts();
            List<ProductInfo> products = new List<ProductInfo>();
            string description;
            double price, total;
            int quantity;
            foreach (IWebElement product in productList) {
                description = getDesription(product);
                price = getPrice(product);
                quantity = getQuantity(product);
                products.Add(new ProductInfo {
                    Description = description,
                    Price = price,
                    Quantity = quantity
                });
            }
            return products;
        }
    }
}
