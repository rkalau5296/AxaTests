using AxaTests.GoogleMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Constraints;
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
            //chromeOptions.AddArgument("--headless");
            //EdgeOptions edgeOptions = new EdgeOptions();
            //edgeOptions.AddArgument("--headless");
            //FirefoxOptions firefoxOptions = new FirefoxOptions();
            //firefoxOptions.AddArgument("--headless");

            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Axa Tests", "geckodriver.exe");
            //service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";            
            
            driver = new ChromeDriver(chromeOptions);
            //driver = new EdgeDriver(edgeOptions);
            //driver = new FirefoxDriver(service, firefoxOptions);
            
            googleMaps = new GoogleMapsPageObjects(driver);
            googleMaps.GoToPage();
            googleMaps.ClickModal();
            googleMaps.Route.Click();
            
            
        }

        [TestMethod]
        public void OnFootFromChlodnaToPlDefilad()
        {
            googleMaps.ChooseRoutingMethod("Pieszo");
            googleMaps.YourLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.LoopFrom();
            googleMaps.TargetLocationInput("plac Defilad 1, 00-901 Warszawa");
            googleMaps.LoopTo();

            var directionTripsList = googleMaps.FindSectionDirectionTrip();
            googleMaps.CheckTheTimesAndDistances(directionTripsList, 40, 3);


        }
        [TestMethod]
        public void ByBicycleFromRumianaToFloriana()
        {
            googleMaps.ChooseRoutingMethod("Na rowerze");           
            googleMaps.YourLocationInput("Rumiana 38, 05-850 Ożarów Mazowiecki");
            googleMaps.LoopFrom();            
            googleMaps.TargetLocationInput("Floriana 1, 05-850 Ożarów Mazowiecki");
            googleMaps.LoopTo();
            
            var directionTripsList = googleMaps.FindSectionDirectionTrip();
            googleMaps.CheckTheTimesAndDistances(directionTripsList, 4, 2);

        }
        [TestMethod]
        public void ByBicycleFromRumianaToTargDrzewny()
        {
            googleMaps.ChooseRoutingMethod("Na rowerze");
            googleMaps.YourLocationInput("Rumiana 38, 05-850 Ożarów Mazowiecki");
            googleMaps.LoopFrom();
            googleMaps.TargetLocationInput("Targ Drzewny 1, 80-886 Gdańsk");
            googleMaps.LoopTo();

            var directionTripsList = googleMaps.FindSectionDirectionTrip();
            googleMaps.CheckTheTimesAndDistances(directionTripsList, 20, 400);

        }
        [TestMethod]
        public void ByBicycleFromPlDefiladToChlodna()
        {
            googleMaps.ChooseRoutingMethod("Na rowerze");
            googleMaps.YourLocationInput("plac Defilad 1, 00-901 Warszawa");
            googleMaps.LoopFrom();
            googleMaps.TargetLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.LoopTo();            

            var directionTripsList = googleMaps.FindSectionDirectionTrip();

            googleMaps.CheckTheTimesAndDistances(directionTripsList, 15, 3);           

        }
        [TestMethod]
        public void OnFootFromPlDefiladToChlodna()
        {
            googleMaps.ChooseRoutingMethod("Pieszo");
            googleMaps.YourLocationInput("plac Defilad 1, 00-901 Warszawa");
            googleMaps.LoopFrom();
            googleMaps.TargetLocationInput("Chłodna 51, 00-867 Warszawa");
            googleMaps.LoopTo();

            var directionTripsList = googleMaps.FindSectionDirectionTrip();

            googleMaps.CheckTheTimesAndDistances(directionTripsList, 40, 3);
            
        }
        [TestMethod]
        public void FromHomeToHotelByCar()
        {
            googleMaps.ChooseRoutingMethod("Samochodem");
            googleMaps.YourLocationInput("Rumiana 38, 05-850 Ożarów Mazowiecki");
            googleMaps.LoopFrom();            
            googleMaps.TargetLocationInput("Hotel Gołębiewski, Karkonoska 14, 58-540 Karpacz");            
            googleMaps.LoopTo();

            var list = driver.FindElements(By.XPath("//div[contains(@id, 'section-directions-trip')]"));

            var directionTripsList = googleMaps.FindSectionDirectionTrip();

            googleMaps.CheckTheTimesAndDistances(directionTripsList, 19, 1900);

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
