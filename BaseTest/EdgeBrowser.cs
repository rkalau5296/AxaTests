using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace AxaTests.BaseTest
{
    internal class EdgeBrowser : Browser
    {        
        public override IWebDriver RunBrowser(IWebDriver driver)
        {
            EdgeOptions edgeOptions = new();
            edgeOptions.AddArgument("--headless");
            edgeOptions.AddArgument("--start-maximized");

            return new EdgeDriver(edgeOptions);
        }
    }
}