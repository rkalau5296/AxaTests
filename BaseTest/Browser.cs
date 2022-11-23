using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxaTests.BaseTest
{
    public abstract class Browser
    {
        public abstract IWebDriver RunBrowser(IWebDriver driver);
    }
}
