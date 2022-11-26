using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AxaTests.BaseTest
{
    internal class FirefoxBrowser : Browser
    {
        private IWebDriver driver;

        public FirefoxBrowser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public override IWebDriver RunBrowser(IWebDriver driver)
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            //firefoxOptions.AddArgument("--headless");
            firefoxOptions.AddArgument("start-maximized");
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\AxaTests", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            return new FirefoxDriver(service, firefoxOptions);
        }
    }
}