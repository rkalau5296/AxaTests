using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxaTests.BaseTest
{
    public class BrowserFactory
    {
        private readonly IWebDriver driver;
        public BrowserFactory(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Browser RunBrowser(BrowserType type)
        {
            return type switch
            {
                BrowserType.Chrome => new ChromeBrowser(driver),
                BrowserType.Edge => new EdgeBrowser(driver),
                BrowserType.Firefox => new FirefoxBrowser(driver),
                _ => throw new Exception($"Type {type} is not handled.")
            };
        }
    }
}
