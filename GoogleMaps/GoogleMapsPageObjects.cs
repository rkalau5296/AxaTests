﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace AxaTests.GoogleMaps
{
    public class GoogleMapsPageObjects
    {
        private readonly IWebDriver driver;
        private readonly string url = "https://www.google.pl/maps/";
        
        public GoogleMapsPageObjects(IWebDriver driver)
        {
            this.driver = driver;            
        }
        
        public IWebElement Route => driver.FindElement(By.Id("hArJGc"));        
        public IWebElement InputFrom => driver.FindElement(By.CssSelector("#sb_ifc50 > input"));
        public IWebElement InputTo => driver.FindElement(By.XPath("//*[@id='sb_ifc51']/input"));

        public void YourLocationInput(string locationFrom)
        {
            Thread.Sleep(1000);
            InputFrom.SendKeys(locationFrom);
        }
        public void LoopFrom()
        {
            var loopsFrom = driver.FindElements(By.XPath("//*[@id='directions-searchbox-0']/button"));
            foreach (var loop in loopsFrom)
            {
                var attribute = loop.GetAttribute("aria-label");
                if (attribute == "Szukaj")
                {
                    try
                    {
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                        executor.ExecuteScript("arguments[0].click();", loop);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public void LoopTo()
        {
            var loopsFrom = driver.FindElements(By.XPath("//*[@id='directions-searchbox-1']/button"));
            foreach (var loop in loopsFrom)
            {
                var attribute = loop.GetAttribute("aria-label");
                if (attribute == "Szukaj")
                {
                    try
                    {
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                        executor.ExecuteScript("arguments[0].click();", loop);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        public void TargetLocationInput(string locationTo)
        {
            InputTo.SendKeys(locationTo);
        }       
        
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);            
        }
        
        public void ChooseRoutingMethod(string routingMethod)
        {
            Thread.Sleep(500);
            var divs = driver.FindElements(By.XPath("//*[@class='FkdJRd vRIAEd dS8AEf']/div"));
            
            for (int i = 0; i < divs.Count; i++)
            {
                Thread.Sleep(500);
                var button = divs[i].FindElement(By.XPath("button/img"));
                Thread.Sleep(500);
                var attribute = button.GetAttribute("aria-label");
                Thread.Sleep(500);
                if (attribute == routingMethod)
                {
                    Thread.Sleep(500);
                    button.Click();
                }
            }
        }
        public void ClickModal()        
        {
            var googleModal = driver.FindElements(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div/div/div[2]/div[1]/div[3]/div[1]/div[1]/form[2]/div/div/button/span"));
            var edgeModal = driver.FindElements(By.CssSelector("[value='Zgadzam się']"));
            if (googleModal.Any())
            {
                googleModal.First().Click();
            }
                
            else if (edgeModal.Any())
            {
                edgeModal.First().Click();
            }
            
        }                            
        
        public ReadOnlyCollection<IWebElement> FindSectionDirectionTrip()
        {            
            var dataInDiv = driver.FindElements(By.XPath("//div[contains (@id, 'section-directions-trip')]"));
            while (dataInDiv.Count == 0)
                dataInDiv = driver.FindElements(By.XPath("//div[contains (@id, 'section-directions-trip')]"));

            return dataInDiv;
        }
        public void CheckTheTimesAndDistances(ReadOnlyCollection<IWebElement> directionTripsList, int expectedTime, int expectedDistance)
        {
            foreach (var directionTrip in directionTripsList)
            {
                string[] newData = directionTrip.Text.Replace("\r\n", " ")
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Except(new string[] { "godz.", "min", "km" })
                                .ToArray();

                if (directionTrip.Text.Contains("godz."))
                {
                    
                    if (!directionTrip.Text.Contains("min"))
                    {
                        int hours = int.Parse(newData[0]);                        
                        double distance = double.Parse(newData[1]);
                        Assert.IsTrue(hours != 0);                        
                        Assert.IsTrue(distance != 0);
                        Assert.IsTrue(hours < expectedTime);
                        Assert.IsTrue(distance < expectedDistance);
                        continue;
                    }
                    if (!directionTrip.Text.Contains("km"))
                    {
                        int hours = int.Parse(newData[0]);
                        int minutes = int.Parse(newData[0]);                        
                        Assert.IsTrue(hours != 0);
                        Assert.IsTrue(minutes != 0);                        
                        Assert.IsTrue(hours < expectedTime);
                        Assert.IsTrue(minutes < expectedTime);
                        continue;
                    }
                    else
                    {
                        int hours = int.Parse(newData[0]);
                        int minutes = int.Parse(newData[0]);
                        double distance = double.Parse(newData[2]);
                        Assert.IsTrue(hours != 0);
                        Assert.IsTrue(minutes != 0);
                        Assert.IsTrue(distance != 0);
                        Assert.IsTrue(hours < expectedTime);
                        Assert.IsTrue(minutes < expectedTime);
                        Assert.IsTrue(distance < expectedDistance);
                        continue;
                    }
                }
                else
                {                    
                    int minutes = int.Parse(newData[0]);
                    double distance = double.Parse(newData[1]);
                    Assert.IsTrue(minutes != 0);
                    Assert.IsTrue(distance != 0);
                    Assert.IsTrue(minutes < expectedTime);
                    Assert.IsTrue(distance < expectedDistance);
                    continue;
                }

            }
        }        
    }
}
