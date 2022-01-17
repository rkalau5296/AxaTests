using OpenQA.Selenium;
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

     
        IWebElement Pieszo  => driver.FindElement(By.CssSelector("[aria-label='Pieszo']"));
        IWebElement NaRowerze => driver.FindElement(By.CssSelector("[aria-label='Na rowerze']"));


        public void YourLocationInput(string locationFrom)
        {
            IWebElement inputFrom = driver.FindElement(By.CssSelector("[placeholder='Wybierz punkt początkowy lub kliknij mapę...']"));
            inputFrom.SendKeys(locationFrom);
        }

        public void TargetLocationInput(string locationTo)
        {
            IWebElement inputTo = driver.FindElement(By.CssSelector("[placeholder='Wybierz punkt docelowy lub kliknij mapę...']"));            
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
            Thread.Sleep(2000);
            Pieszo.Click();
        }
        public void ClickByBicycle()
        {         
            Thread.Sleep(2000);
            NaRowerze.Click();
        }
        public void ClickModal()
        {             
            driver.FindElement(By.XPath("//*[contains (text(), 'Zgadzam się')]")).Click();
        }

    }
}
