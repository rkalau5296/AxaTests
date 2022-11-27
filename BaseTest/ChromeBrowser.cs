using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AxaTests.BaseTest
{
    internal class ChromeBrowser : Browser
    {       
        public override IWebDriver RunBrowser(IWebDriver driver)
        {
            ChromeOptions chromeOptions = new();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-maximized");
            return new ChromeDriver(chromeOptions);
        }
    }
}