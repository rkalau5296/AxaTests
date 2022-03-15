using AxaTests.GoogleMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AxaTests
{
    [TestClass]
    public class GoogleMapsTestSuite
    {
        IWebDriver driver;

        IList<IWebElement> times;
        IList<IWebElement> distances;
        GoogleMapsPageObjects googleMaps;

        [TestInitialize]
        public void Test()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--headless");
            
            //driver = new ChromeDriver(chromeOptions);
            driver = new EdgeDriver(edgeOptions);
            
            googleMaps = new GoogleMapsPageObjects(driver);
            googleMaps.GoToPage();           
            googleMaps.ClickModal();
            googleMaps.Route.Click();
            
        }

        [TestMethod]
        public void OnFootFromChlodnaToPlDefilad()
        {
            googleMaps.ClickOnFoot();
            googleMaps.YourLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.YourLocationInputSearchButton.Click();
            googleMaps.TargetLocationInput("plac Defilad 1, 00-901 Warszawa");
            googleMaps.TargetLocationInputSearchButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-duration gm2-subtitle-alt-1']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-tUvA6e xB1mrd-T3iPGc-iSfDt-K4efff-text gm2-body-2']")));

            times = googleMaps.FindTimes();
            distances = googleMaps.FindDistances();         
            

            foreach (IWebElement time in times)
            {
                int trimedTime = int.Parse(time.Text.Trim(new char[] { ' ', 'm', 'i', 'n' }));
                Assert.IsTrue(trimedTime < 40, "The route's time is less then 40 min.");
            }
            foreach (IWebElement distance in distances)
            {
                double trimedDisnace = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDisnace <= 3, "The route's distance is less then 3 min.");
            }

        }
        [TestMethod]
        public void ByBicycleFromChlodnaToPlDefilad()
        {
            googleMaps.ClickByBicycle();
            googleMaps.YourLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.YourLocationInputSearchButton.Click();
            googleMaps.TargetLocationInput("plac Defilad 1, 00-901 Warszawa");
            googleMaps.TargetLocationInputSearchButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-duration gm2-subtitle-alt-1']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-tUvA6e xB1mrd-T3iPGc-iSfDt-K4efff-text gm2-body-2']")));

            times = googleMaps.FindTimes();
            distances = googleMaps.FindDistances();

            foreach (IWebElement time in times)           
            {
                int trimedTime = int.Parse(time.Text.Trim(new char[] { ' ', 'm', 'i', 'n' }));
                Assert.IsTrue(trimedTime < 15, "The route's time is less then 15 min.");            
            }
            foreach (IWebElement distance in distances)
            {
                double trimedDisnace = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDisnace <= 3, "The route's distance is less then 3 min.");
            }
        }
        [TestMethod]
        public void ByBicycleFromPlDefiladToChlodna()
        {
            googleMaps.ClickByBicycle();
            googleMaps.YourLocationInput("plac Defilad 1, 00-901 Warszawa");
            googleMaps.YourLocationInputSearchButton.Click();
            googleMaps.TargetLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.TargetLocationInputSearchButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-duration gm2-subtitle-alt-1']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-tUvA6e xB1mrd-T3iPGc-iSfDt-K4efff-text gm2-body-2']")));

            times = googleMaps.FindTimes();
            distances = googleMaps.FindDistances();

            foreach (IWebElement time in times)
            {
                int trimedTime = int.Parse(time.Text.Trim(new char[] { ' ', 'm', 'i', 'n' }));
                Assert.IsTrue(trimedTime < 15, "The route's time is less then 15 min.");
            }
            foreach (IWebElement distance in distances)
            {
                double trimedDisnace = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDisnace <= 3, "The route's distance is less then 3 km.");
            }            

        }
        [TestMethod]
        public void OnFootFromPlDefiladToChlodna()
        {
            googleMaps.ClickOnFoot();
            googleMaps.YourLocationInput("plac Defilad 1, 00-901 Warszawa");
            googleMaps.YourLocationInputSearchButton.Click();
            googleMaps.TargetLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.TargetLocationInputSearchButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-duration gm2-subtitle-alt-1']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-tUvA6e xB1mrd-T3iPGc-iSfDt-K4efff-text gm2-body-2']")));

            times = googleMaps.FindTimes();
            distances = googleMaps.FindDistances();

            foreach (IWebElement time in times)
            {
                int trimedTime = int.Parse(time.Text.Trim(new char[] { ' ', 'm', 'i', 'n' }));
                Assert.IsTrue(trimedTime < 40, "The route's time is less then 40 min.");
            }
            foreach (IWebElement distance in distances)
            {
                double trimedDisnace = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDisnace <= 3, "The route's distances is less then 3 km.");
            }
        }
        [TestMethod]
        public void FromHomeToHotelByCar()
        {
            googleMaps.ClickByCar();
            googleMaps.YourLocationInput("Rumiana 38, 05-850 Ożarów Mazowiecki");
            googleMaps.YourLocationInputSearchButton.Click();            
            googleMaps.TargetLocationInput("Via Lucio Papirio, 61-1, 00174 Roma RM, Włochy");
            //googleMaps.TargetLocationInput("Karkonoska 14, 58-540 Karpacz");
            googleMaps.TargetLocationInputSearchButton.Click();            

            while (googleMaps.isVisible());
            

            times = googleMaps.FindTimesByCar();
            distances = googleMaps.FindDistances();


            foreach(var time in times)
            {
                string[] sub = time.Text.Split();
                int hours = int.Parse(sub[0]);
                int minutes = int.Parse(sub[2]);
                Assert.IsTrue(hours < 25 && minutes < 1420);
            }
            
            foreach (IWebElement distance in distances)
            {
                double trimedDistance = double.Parse(distance.Text.Trim(new char[] { ' ', 'k', 'm' }));
                Assert.IsTrue(trimedDistance <= 2700, "The route's distances is less then 700 km.");
            }
        }

        

        [TestCleanup]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
