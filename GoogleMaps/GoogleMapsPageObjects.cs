using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

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
            driver.FindElement(By.CssSelector("[aria-label='Pieszo']")).Click();
        }
        public void ClickByBicycle()
        {
            driver.FindElement(By.CssSelector("[aria-label='Na rowerze']")).Click();
        }
        public void ClickModal()
        {             
            driver.FindElement(By.XPath("//*[contains (text(), 'Zgadzam się')]")).Click();
        }

    }
}
