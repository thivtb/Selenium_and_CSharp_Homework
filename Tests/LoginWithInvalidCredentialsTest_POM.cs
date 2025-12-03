using c__basic_SD5858_VoThiBeThi_section1.Configs;
using c__basic_SD5858_VoThiBeThi_section1.PageObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace c__basic_SD5858_VoThiBeThi_section1;

public class LoginWithInvalidCredentialsTest
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
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void LoginWithInvalidCredentials()
    {
        string invalidEmail = settings.InvalidLogin.Email;
        string invalidPassword = settings.InvalidLogin.Password;
        string validEmail = settings.ValidLogin.Email;
        string validPassword = settings.ValidLogin.Password;

        driver.Url = settings.BaseUrl;
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
        homePage.login(invalidEmail, invalidPassword);

        // Verify error 'Your email or password is incorrect!' is visible
        IWebElement errorMsg = homePage.getErrorMsg();
        Assert.IsTrue(errorMsg.Displayed, "Error message 'Your email or password is incorrect!' is invisible");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
