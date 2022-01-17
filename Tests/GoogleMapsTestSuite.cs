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
            googleMaps.ClickModal();
            googleMaps.ClickRoute();            
        }

        [TestMethod]
        public void OnFootFromChlodnaToPlDefilad()
        {
            googleMaps.ClickOnFoot();
            googleMaps.YourLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.TargetLocationInput("plac Defilad 1, 00-901 Warszawa");
            driver.FindElement(By.CssSelector("[aria-label='Zamień punkt początkowy i docelowy']")).Click();
            driver.FindElement(By.CssSelector("[aria-label='Zamień punkt początkowy i docelowy']")).Click();

            IList<IWebElement> times = driver.FindElements(By.CssSelector("[jstcache='1158']"));
            IList<IWebElement> distances = driver.FindElements(By.CssSelector("[jstcache='1159']"));

            foreach (IWebElement time in times)
            {
                int trimedTime = int.Parse(time.Text.Trim(new char[] { ' ', 'm', 'i', 'n' }));
                Assert.IsTrue(trimedTime < 40, "The route's time is less then 40 min.");
            }
            foreach (IWebElement distance in distances)
            {
                double trimedDisnace = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDisnace < 40, "The route's time is less then 40 min.");
            }

        }
        [TestMethod]
        public void ByBicycleFromChlodnaToPlDefilad()
        {
            googleMaps.ClickByBicycle();           
            googleMaps.YourLocationInput("Chłodna 51, 00-867 Warszawa");            
            googleMaps.TargetLocationInput("plac Defilad 1, 00-901 Warszawa");            
            driver.FindElement(By.CssSelector("[aria-label='Zamień punkt początkowy i docelowy']")).Click();
            driver.FindElement(By.CssSelector("[aria-label='Zamień punkt początkowy i docelowy']")).Click();
            
            IList<IWebElement> times = driver.FindElements(By.CssSelector("[jstcache='1158']"));
            IList<IWebElement> distances = driver.FindElements(By.CssSelector("[jstcache='1159']"));
          
            foreach (IWebElement time in times)           
            {
                int trimedTime = int.Parse(time.Text.Trim(new char[] { ' ', 'm', 'i', 'n' }));
                Assert.IsTrue(trimedTime < 40, "The route's time is less then 40 min.");            
            }
            foreach (IWebElement distance in distances)
            {
                double trimedDisnace = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDisnace < 40, "The route's time is less then 40 min.");
            }
        }
        [TestMethod]
        public void ByBicycleFromPlDefiladToChlodna()
        {
            googleMaps.ClickByBicycle();
            googleMaps.YourLocationInput("plac Defilad 1, 00-901 Warszawa");
            googleMaps.TargetLocationInput("Chłodna 51, 00-867 Warszawa");
            
            driver.FindElement(By.CssSelector("[aria-label='Zamień punkt początkowy i docelowy']")).Click();
            driver.FindElement(By.CssSelector("[aria-label='Zamień punkt początkowy i docelowy']")).Click();

            IList<IWebElement> times = driver.FindElements(By.CssSelector("[jstcache='1158']"));
            IList<IWebElement> distances = driver.FindElements(By.CssSelector("[jstcache='1159']"));

            foreach (IWebElement time in times)
            {
                int trimedTime = int.Parse(time.Text.Trim(new char[] { ' ', 'm', 'i', 'n' }));
                Assert.IsTrue(trimedTime < 15, "The route's time is less then 15 min.");
            }
            foreach (IWebElement distance in distances)
            {
                double trimedDisnace = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDisnace < 3, "The first route's distances is less then 3 km.");
            }            

        }
        [TestMethod]
        public void OnFootFromPlDefiladToChlodna()
        {
            googleMaps.ClickByBicycle();
            googleMaps.YourLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.TargetLocationInput("plac Defilad 1, 00-901 Warszawa");

            driver.FindElement(By.CssSelector("[aria-label='Zamień punkt początkowy i docelowy']")).Click();
            driver.FindElement(By.CssSelector("[aria-label='Zamień punkt początkowy i docelowy']")).Click();

            IList<IWebElement> times = driver.FindElements(By.CssSelector("[jstcache='1158']"));
            IList<IWebElement> distances = driver.FindElements(By.CssSelector("[jstcache='1159']"));

            foreach (IWebElement time in times)
            {
                int trimedTime = int.Parse(time.Text.Trim(new char[] { ' ', 'm', 'i', 'n' }));
                Assert.IsTrue(trimedTime < 15, "The route's time is less then 15 min.");
            }
            foreach (IWebElement distance in distances)
            {
                double trimedDisnace = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDisnace < 3, "The first route's distances is less then 3 km.");
            }
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
