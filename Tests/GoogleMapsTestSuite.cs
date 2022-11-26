using AxaTests.BaseTest;
using AxaTests.GoogleMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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
    public class GoogleMapsTestSuite : BasicTest
    {        

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

            var directionTripsList = googleMaps.FindSectionDirectionTrip();

            googleMaps.CheckTheTimesAndDistances(directionTripsList, 19, 1900);
        }
        [TestMethod]
        public void FromHomeToHotelOnFoot()
        {
            googleMaps.ChooseRoutingMethod("Pieszo");
            googleMaps.YourLocationInput("Rumiana 38, 05-850 Ożarów Mazowiecki");
            googleMaps.LoopFrom();
            googleMaps.TargetLocationInput("Hotel Gołębiewski, Karkonoska 14, 58-540 Karpacz");
            googleMaps.LoopTo();

            var directionTripsList = googleMaps.FindSectionDirectionTrip();

            googleMaps.CheckTheTimesAndDistances(directionTripsList, 91, 500);
        }
        [TestMethod]
        public void FromHomeToHotelOnTrain()
        {
            googleMaps.ChooseRoutingMethod("Transportem publicznym");
            googleMaps.YourLocationInput("Rumiana 38, 05-850 Ożarów Mazowiecki");
            googleMaps.LoopFrom();
            googleMaps.TargetLocationInput("Hotel Gołębiewski, Karkonoska 14, 58-540 Karpacz");
            googleMaps.LoopTo();

            var directionTripsList = googleMaps.FindSectionDirectionTrip();

            googleMaps.CheckTheTimesAndDistances(directionTripsList, 18, 500);
        }
        [TestMethod]
        public void FromHomeToHotelOnBike()
        {
            googleMaps.ChooseRoutingMethod("Na rowerze");
            googleMaps.YourLocationInput("Rumiana 38, 05-850 Ożarów Mazowiecki");
            googleMaps.LoopFrom();
            googleMaps.TargetLocationInput("Hotel Gołębiewski, Karkonoska 14, 58-540 Karpacz");
            googleMaps.LoopTo();

            var directionTripsList = googleMaps.FindSectionDirectionTrip();

            googleMaps.CheckTheTimesAndDistances(directionTripsList, 30, 500);
        }
        
    }
}
