using AxaTests.GoogleMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AxaTests
{
    [TestClass]
    public class GoogleMapsTestSuite
    {
        IWebDriver driver = new ChromeDriver();

        GoogleMapsPageObjects googleMaps;

        [TestInitialize]
        public void Test()
        {
            googleMaps = new GoogleMapsPageObjects(driver);
            googleMaps.GoToPage();
            Thread.Sleep(2000);
            googleMaps.ClickModal();
            googleMaps.ClickRoute();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void OnFootFromChlodnaToPlDefilad()
        {
            googleMaps.ClickOnFoot();
            Thread.Sleep(2000);
            googleMaps.YourLocationInput("Chłodna 51, 00-867 Warszawa");
            Thread.Sleep(2000);
            googleMaps.SearchLoopFrom();
            Thread.Sleep(2000);
            googleMaps.TargetLocationInput("plac Defilad 1, 00-901 Warszawa");
            Thread.Sleep(2000);
            googleMaps.SearchLoopTo();
            Thread.Sleep(2000);
            List<int> times = googleMaps.FromChlodnaToPlDefiladTimes();
            List<double> distances = googleMaps.FromChlodnaToPlDefiladDistances();

            Assert.IsTrue(times[0] < 40, "The first route's time is less then 40 min.");
            Assert.IsTrue(times[1] < 40, "The second route's time is less then 40 min.");
            Assert.IsTrue(distances[0] < 3, "The first route's distances is less then 3 km.");
            Assert.IsTrue(distances[1] < 3, "The second route's distances is less then 3 km.");

        }
        [TestCleanup]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
