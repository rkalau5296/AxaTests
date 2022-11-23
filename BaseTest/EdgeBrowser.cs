using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace AxaTests.BaseTest
{
    internal class EdgeBrowser : Browser
    {
        private IWebDriver driver;

        public EdgeBrowser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public override IWebDriver RunBrowser(IWebDriver driver)
        {
            EdgeOptions edgeOptions = new();
            edgeOptions.AddArgument("--headless");
            edgeOptions.AddArgument("start-maximized");

            return new EdgeDriver(edgeOptions);
        }
    }
}