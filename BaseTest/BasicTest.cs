using AxaTests.GoogleMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AxaTests.BaseTest
{
    [TestClass]
    public class BasicTest
    {
        public IWebDriver driver;
        public GoogleMapsPageObjects googleMaps;

        [TestInitialize]
        public void Open()
        {
            BrowserFactory browserFactory = new();
            Browser runningBbrowser = browserFactory.RunBrowser(BrowserType.Edge);
            driver = runningBbrowser.RunBrowser(driver);
            
            googleMaps = new(driver);
            googleMaps.GoToPage();
            googleMaps.ClickModal();
            googleMaps.Route.Click();

        }
        [TestCleanup]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

    }
}
