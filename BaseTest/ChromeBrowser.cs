using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AxaTests.BaseTest
{
    internal class ChromeBrowser : Browser
    {
        private IWebDriver driver;

        public ChromeBrowser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public override IWebDriver RunBrowser(IWebDriver driver)
        {
            ChromeOptions chromeOptions = new();
            //chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("start-maximized");
            return new ChromeDriver(chromeOptions);
        }
    }
}