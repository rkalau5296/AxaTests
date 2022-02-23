﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
        public IWebElement NaRowerze => driver.FindElement(By.CssSelector("[aria-label='Na rowerze']"));
        public IWebElement YourLocationInputSearchButton => driver.FindElement(By.XPath("//*[@id='directions-searchbox-0']/button[1]"));
        public IWebElement TargetLocationInputSearchButton => driver.FindElement(By.XPath("//*[@id='directions-searchbox-1']/button[1]"));
        public IWebElement Route => driver.FindElement(By.ClassName("xoLGzf-T3iPGc-icon"));


        public void YourLocationInput(string locationFrom)
        {
            IWebElement inputFrom = driver.FindElement(By.XPath("//*[@id='sb_ifc51']/input"));
            inputFrom.SendKeys(locationFrom);
        }

        public void TargetLocationInput(string locationTo)
        {
            IWebElement inputTo = driver.FindElement(By.XPath("//*[@id='sb_ifc52']/input"));            
            inputTo.SendKeys(locationTo);
        }

        public void ClickRoute()
        {
            driver.FindElement(By.ClassName("xoLGzf-T3iPGc-icon")).Click();
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
        public void ClickByBicycle()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[aria-label='Na rowerze']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(NaRowerze)).Click();            
        }
        public void ClickModal()        {            
            
            var element = driver.FindElements(By.XPath("//*[contains (text(), 'Zgadzam się')]"));
            if (element.Count>0)
                element[0].Click();
            else
            driver.FindElement(By.CssSelector("[value='Zgadzam się']")).Click();
        }

        public IList<IWebElement> FindTimes()
        {
            return driver.FindElements(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-duration gm2-subtitle-alt-1']"));            
        }
        public IList<IWebElement> FindDistances()
        {
            return driver.FindElements(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-tUvA6e xB1mrd-T3iPGc-iSfDt-K4efff-text gm2-body-2']"));
        }

    }
}
