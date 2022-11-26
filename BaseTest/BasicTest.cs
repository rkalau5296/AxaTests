using AxaTests.GoogleMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BrowserFactory browserFactory = new(driver);
            Browser runningBbrowser = browserFactory.RunBrowser(BrowserType.Firefox);
            driver = runningBbrowser.RunBrowser(driver);

            driver.Navigate().GoToUrl("https://www.google.com/");
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
