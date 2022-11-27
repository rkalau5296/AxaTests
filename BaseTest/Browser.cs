using OpenQA.Selenium;

namespace AxaTests.BaseTest
{
    public abstract class Browser
    {
        public abstract IWebDriver RunBrowser(IWebDriver driver);
    }
}
