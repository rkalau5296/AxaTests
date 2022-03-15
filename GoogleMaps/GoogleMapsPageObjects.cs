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

     
        public IWebElement Pieszo  => driver.FindElement(By.CssSelector("[aria-label='Pieszo']"));
        public IWebElement NaRowerze => driver.FindElement(By.CssSelector("[aria-label='Na rowerze']"));
        public IWebElement YourLocationInputSearchButton => driver.FindElement(By.XPath("//*[@id='directions-searchbox-0']/button[1]"));
        //public IWebElement TargetLocationInputSearchButton => driver.FindElement(By.XPath("//*[@id='directions-searchbox-1']/button[1]"));
        public IWebElement TargetLocationInputSearchButton => driver.FindElement(By.CssSelector("#directions-searchbox-1 > button.nhb85d-BIqFsb"));

        public IWebElement Route => driver.FindElement(By.CssSelector("#xoLGzf-T3iPGc > .xoLGzf-T3iPGc-icon"));

        public IWebElement Samochodem => driver.FindElement(By.CssSelector("#omnibox-directions > div > div.Zvyb8e-T3iPGc-urwkYd-WAutxc-OomVLb-haAclf > div > div > div.z8Wzid-wcotoc-vAeulc-wwuYjd.Wnt0je-urwkYd-WAutxc-NGme3c > div:nth-child(2) > button > img"));

        public void YourLocationInput(string locationFrom)
        {
            //IWebElement inputFrom = driver.FindElement(By.XPath("//*[@id='sb_ifc51']/input"));
            IWebElement inputFrom = driver.FindElement(By.CssSelector("#sb_ifc51 > input"));
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

            //var element = driver.FindElements(By.XPath("//*[contains (text(), 'Zgadzam się')]"));
            //var element = driver.FindElements(By.CssSelector("#yDmH0d > c-wiz > div > div > div > div.NIoIEf > div.G4njw > div.AIC7ge > form > div > div > button > span"));
            var element = driver.FindElements(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div/div/div[2]/div[1]/div[4]/form/div/div/button/span"));
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
        public void ClickByCar()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#omnibox-directions > div > div.Zvyb8e-T3iPGc-urwkYd-WAutxc-OomVLb-haAclf > div > div > div.z8Wzid-wcotoc-vAeulc-wwuYjd.Wnt0je-urwkYd-WAutxc-NGme3c > div:nth-child(2) > button > img")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Samochodem)).Click();
            //Samochodem.Click();
        }
        public IList<IWebElement> FindTimesByCar()
        {
            return driver.FindElements(By.XPath("//div[@class='xB1mrd-T3iPGc-iSfDt-duration gm2-subtitle-alt-1 delay-light']"));
        }

        public IList<IWebElement> FindTimesAndRangesByCar()
        {
            return driver.FindElements(By.CssSelector("[id^=section-directions-trip-]"));
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
    }
}
