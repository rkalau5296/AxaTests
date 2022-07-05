﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace AxaTests.GoogleMaps
{
    public class GoogleMapsPageObjects
    {
        private IWebDriver driver;
        private string url = "https://www.google.pl/maps/";
        
        public GoogleMapsPageObjects(IWebDriver driver)
        {
            this.driver = driver;            
        }
        
        public IWebElement Pieszo  => driver.FindElement(By.CssSelector("[aria-label='Pieszo']"));
        public IWebElement NaRowerze => driver.FindElement(By.XPath("//button[@aria-checked='true']/img"));
        public IWebElement YourLocationInputSearchButton => driver.FindElement(By.XPath("//*[@id='directions-searchbox-0']/button[@data-tooltip='Szukaj]"));        
        public IWebElement TargetLocationInputSearchButton => driver.FindElement(By.XPath("//div[@id='directions-searchbox-1']/button[@aria-label='Szukaj']"));
        public IWebElement Route => driver.FindElement(By.Id("hArJGc"));
        public IWebElement Samochodem => driver.FindElement(By.CssSelector("#omnibox-directions > div > div.Zvyb8e-T3iPGc-urwkYd-WAutxc-OomVLb-haAclf > div > div > div.z8Wzid-wcotoc-vAeulc-wwuYjd.Wnt0je-urwkYd-WAutxc-NGme3c > div:nth-child(2) > button > img"));
        public IWebElement inputFrom => driver.FindElement(By.CssSelector("#sb_ifc51 > input"));
        public IWebElement inputTo => driver.FindElement(By.XPath("//*[@id='sb_ifc52']/input"));

        public void YourLocationInput(string locationFrom)
        {
            Thread.Sleep(1000);
            inputFrom.SendKeys(locationFrom);
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
            inputTo.SendKeys(locationTo);
        }       
        
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);            
        }

        public void ClickOnFoot()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[aria-label='Pieszo']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Pieszo)).Click();           
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
            var googleModal = driver.FindElements(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div/div/div[2]/div[1]/div[4]/form/div/div/button/span"));
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

        public IList<IWebElement> FindTimes()
        {
            return driver.FindElements(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-duration gm2-subtitle-alt-1']"));            
        }

        public IList<IWebElement> FindDistances()
        {
            return driver.FindElements(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-tUvA6e xB1mrd-T3iPGc-iSfDt-K4efff-text gm2-body-2']"));
        }

        public void ClickByCar()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#omnibox-directions > div > div.Zvyb8e-T3iPGc-urwkYd-WAutxc-OomVLb-haAclf > div > div > div.z8Wzid-wcotoc-vAeulc-wwuYjd.Wnt0je-urwkYd-WAutxc-NGme3c > div:nth-child(2) > button > img")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Samochodem)).Click();            
        }

        public IList<IWebElement> FindTimesByCar()
        {
            return driver.FindElements(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-duration gm2-subtitle-alt-1 delay-light']"));
        } 
        
        public bool isVisible()
        {
            var timesVisible = FindTimesByCar();
            var distancesVisible = FindDistances();
            if (timesVisible.Count == 0 || distancesVisible.Count == 0)
            {
                return false;
            }
            return true;
        }
        public ReadOnlyCollection<IWebElement> FindSectionDirectionTrip()
        {
            var dataInDiv = driver.FindElements(By.XPath("//div[contains (@id, 'section-directions-trip')]/div[1]/div[3]/div[1]"));
            while (dataInDiv.Count == 0)
                dataInDiv = driver.FindElements(By.XPath("//div[contains (@id, 'section-directions-trip')]/div[1]/div[3]/div[1]"));

            return dataInDiv;
        }
        public void CheckTheTimesAndDistances(ReadOnlyCollection<IWebElement> directionTripsList, int expectedTime, int expectedDistance)
        {
            foreach (var directionTrip in directionTripsList)
            {
                if (directionTrip.Text.Contains("godz."))
                {
                    string[] newData = directionTrip.Text.Replace("\r\n", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Except(new string[] { "godz.", "min", "km", "\r\n" }).ToArray();
                    int hours = int.Parse(newData[0]);
                    int minutes = int.Parse(newData[1]);
                    int distance = int.Parse(newData[2]);
                    Assert.IsTrue(hours < expectedTime);
                    Assert.IsTrue(distance < expectedDistance);
                }
                else
                {
                    string[] newData = directionTrip.Text.Replace("\r\n", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Except(new string[] { "min", "km", "\r\n" }).ToArray();
                    int minutes = int.Parse(newData[0]);
                    double distance = double.Parse(newData[1]);
                    Assert.IsTrue(minutes < expectedTime);
                    Assert.IsTrue(distance < expectedDistance);
                }

            }
        }
    }
}
