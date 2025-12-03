using c__basic_SD5858_VoThiBeThi_section1.Configs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace c__basic_SD5858_VoThiBeThi_section1.Tests;

public class Excercise2
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
    public void LoginWithCorrectUsernamePassword()
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
        driver.FindElement(By.Name("email")).SendKeys(settings.ValidLogin.Email);
        driver.FindElement(By.Name("password")).SendKeys(settings.ValidLogin.Password);

        // Click 'login' button
        driver.FindElement(By.XPath("//button[text()='Login']")).Click();

        // Verify that 'Logged in as username' is visible
        IWebElement message = driver.FindElement(By.XPath("//a[contains(text(), ' Logged in as ')]"));
        Assert.IsTrue(message.Displayed, "Logged in as username is invisible");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
        driver.Quit();
    }
}
