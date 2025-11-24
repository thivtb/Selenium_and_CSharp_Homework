using c__basic_SD5858_VoThiBeThi_section1.PageObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace c__basic_SD5858_VoThiBeThi_section1;

public class HomePageTest
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        var service = ChromeDriverService.CreateDefaultService();
        driver = new ChromeDriver(service, options);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void Test1()
    {
        string email = "test@gmail.com";
        string password = "password";

        driver.Url = "https://automationexercise.com/";
        HomePage homePage = new HomePage(driver);

        //  Verify that home page is visible successfully
        string title = driver.Title;
        Assert.That(title, Is.EqualTo("Automation Exercise"), "Home page title mismatch.");

        // Click on 'Signup / Login' button
        homePage.clickSignUpLoginBtn();

        // Verify 'Login to your account' is visible
        IWebElement loginPageTitle = homePage.getLoginPageTitle();
        Assert.IsTrue(loginPageTitle.Displayed, "'Login to your account' is invisible");

        //Login with incorrect email and password
        homePage.login("test@gmail.com", "password");

        // Verify error 'Your email or password is incorrect!' is visible
        IWebElement errorMsg = homePage.getErrorMsg();
        Assert.IsTrue(errorMsg.Displayed, "Error message 'Your email or password is incorrect!' is invisible");

        // Clear login form data
        homePage.clearLoginForm();

        //Login with correct email and password
        homePage.login("kejekah234@datoinf.com", "123456");

        // Verify that 'Logged in as username' is visible
        IWebElement loginAs = homePage.getLoginAsText();
        Assert.IsTrue(loginAs.Displayed, "Logged in as username is invisible");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
        driver.Quit();
    }
}
