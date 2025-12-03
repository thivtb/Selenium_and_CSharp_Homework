using c__basic_SD5858_VoThiBeThi_section1.Configs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.WebSockets;

namespace c__basic_SD5858_VoThiBeThi_section1.Tests
{
    public class Tests
    {
        IWebDriver driver;
        private TestSettings settings;

        [SetUp]
        public void Setup()
        {
            settings = TestSettings.LoadSettings();
            var options = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();
            driver = new ChromeDriver(service, options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void LoginWithIncorrectUsernamePassword()
        {
            driver.Url = settings.BaseUrl;

            //  Verify that home page is visible successfully
            string title = driver.Title;
            Assert.That(title, Is.EqualTo("Automation Exercise"), "Home page title mismatch.");

            // Click on 'Signup / Login' button
            driver.FindElement(By.XPath("//a[contains(text(), ' Signup / Login')]")).Click();

            // Verify 'Login to your account' is visible
            IWebElement loginTitle = driver.FindElement(By.XPath("//h2[text()='Login to your account']"));
            Assert.IsTrue(loginTitle.Displayed, "'Login to your account' is invisible");

            // Enter incorrect email address and password
            driver.FindElement(By.Name("email")).SendKeys(settings.InvalidLogin.Email);
            driver.FindElement(By.Name("password")).SendKeys(settings.InvalidLogin.Password);

            // Click 'login' button
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();

            // Verify error 'Your email or password is incorrect!' is visible
            IWebElement errorMsg = driver.FindElement(By.XPath("//form/p[contains(text(),'Your email or password is incorrect!')]"));
            Assert.IsTrue(errorMsg.Displayed, "Error message 'Your email or password is incorrect!' is invisible");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        } 
    }
}