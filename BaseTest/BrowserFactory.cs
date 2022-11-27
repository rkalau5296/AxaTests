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
        public Browser RunBrowser(BrowserType type)
        {
            return type switch
            {
                BrowserType.Chrome => new ChromeBrowser(),
                BrowserType.Edge => new EdgeBrowser(),
                BrowserType.Firefox => new FirefoxBrowser(),
                _ => throw new Exception($"Type {type} is not handled.")
            };
        }
    }
}
