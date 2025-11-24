using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__basic_SD5858_VoThiBeThi_section1.PageObjectModel
{
    internal class HomePage
    {
        IWebDriver driver;
        //WebDriverWait wait;

        By signUpLoginBtn = By.XPath("//a[contains(text(), ' Signup / Login')]");
        By loginTitle = By.XPath("//h2[text()='Login to your account']");

        By tfEmail = By.Name("email");
        By tfPassword = By.Name("password");
        By loginBtn = By.XPath("//button[text()='Login']");
        By errorMsg = By.XPath("//form/p[contains(text(),'Your email or password is incorrect!')]");
        By loginAsText = By.XPath("//a[contains(text(), ' Logged in as ')]");

        public HomePage(IWebDriver driver) { 
            this.driver = driver;
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void clickSignUpLoginBtn()
        {
            driver.FindElement(signUpLoginBtn).Click();
        }

        public IWebElement getLoginPageTitle()
        {
            return driver.FindElement(loginTitle);
        }

        public void inputEmail (string email)
        {
            driver.FindElement(tfEmail).SendKeys(email);
        }

        public void inputPassword(string password)
        {
            driver.FindElement(tfPassword).SendKeys(password);
        }

        public void clickLoginBtn()
        {
            driver.FindElement(loginBtn).Click();
        }

        public void login(string email, string password)
        {
            inputEmail(email);
            inputPassword(password);
            clickLoginBtn();
        }

        public void clearLoginForm()
        {
            driver.FindElement(tfEmail).Clear();
            driver.FindElement(tfPassword).Clear();
        }

        public IWebElement getErrorMsg()
        {
            return driver.FindElement(errorMsg);
        }

        public IWebElement getLoginAsText()
        {
            return driver.FindElement(loginAsText);
        }
    }
}
