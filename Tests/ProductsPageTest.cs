using c__basic_SD5858_VoThiBeThi_section1.Configs;
using c__basic_SD5858_VoThiBeThi_section1.PageObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace c__basic_SD5858_VoThiBeThi_section1;

public class ProductsPageTest
{
    IWebDriver driver;
    WebDriverWait wait;
    Actions actions;
    private TestSettings settings;

    [SetUp]
    public void Setup()
    {
        settings = TestSettings.LoadSettings();
        var options = new ChromeOptions();
        var service = ChromeDriverService.CreateDefaultService();
        driver = new ChromeDriver(service, options);
        actions = new Actions(driver);
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void AddProductToCart()
    {
        driver.Url = settings.BaseUrl;
        ProductsPage productPage = new ProductsPage(driver);
       
        //  Verify that home page is visible successfully
        string title = driver.Title;
        Assert.That(title, Is.EqualTo("Automation Exercise"), "Home page title mismatch.");

        // Click product button
        productPage.clickProductBtn();
        IList<IWebElement> allProducts = productPage.getProductList();

        List<ProductInfo> expectedProducts = new List<ProductInfo>();
        ProductInfo firstProduct = productPage.getProductInfor(allProducts[0]);
        productPage.addProductToCart(allProducts[0]);
        productPage.clickContinueShopping();

        ProductInfo secondProduct = productPage.getProductInfor(allProducts[1]);
        productPage.addProductToCart(allProducts[1]);
        productPage.clickCartBtn();


        CartPage cartPage = new CartPage(driver);
        IList<ProductInfo> cartProductList = cartPage.getCartProducts();
        Assert.That(cartProductList.Count, Is.EqualTo((int)expectedProducts.Count), "The number of products is incorrect");

        ProductInfo expected, actual;
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            expected = expectedProducts[i];
            actual = cartProductList[i];

            Assert.That(actual.Description, Is.EqualTo(expected.Description), $"Product name {i + 1} is incorrect");
            Assert.That(actual.Price, Is.EqualTo(expected.Price), $"Price {i + 1} is incorrect");
        }
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
        driver.Quit();
    }
}
