using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

        public void SearchLoopFrom()
        {
            driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[3]/div[1]/div[2]/div/div[3]/div[1]/div[1]/div[2]/button[1]")).Click();
        }

        public void SearchLoopTo()
        {
            driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[3]/div[1]/div[2]/div/div[3]/div[1]/div[2]/div[2]/button[1]")).Click();
        }

        public List<int> FromChlodnaToPlDefiladTimes()
        {            
            var time1 = driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[7]/div/div[1]/div/div/div[5]/div[1]/div[1]/div[3]/div[1]/div[1]")).Text.Trim(new char[] { ' ', 'm', 'i', 'n' });
            var intTime1 = int.Parse(time1);

            var time2 = driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[7]/div/div[1]/div/div/div[5]/div[2]/div[1]/div[3]/div[1]/div[1]")).Text.Trim(new char[] { ' ', 'm', 'i', 'n' });
            var intTime2 = int.Parse(time2);

            List<int> times = new List<int>();

            times.Add(intTime1);
            times.Add(intTime2);

            return times;
        }
        public List<double> FromChlodnaToPlDefiladDistances()
        {
            var distance1 = driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[7]/div/div[1]/div/div/div[5]/div[1]/div[1]/div[3]/div[1]/div[2]")).Text.Trim(new char[] { ' ', 'k', 'm' });
            var intdistance1 = double.Parse(distance1);

            var distance2 = driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[7]/div/div[1]/div/div/div[5]/div[2]/div[1]/div[3]/div[1]/div[2]")).Text.Trim(new char[] { ' ', 'k', 'm' });
            var intdistance2 = double.Parse(distance2);

            List<double> distances = new List<double>();

            distances.Add(intdistance1);
            distances.Add(intdistance2);

            return distances;
        }
        public void YourLocationInput(string locationFrom)
        {
            var inputFrom = driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[3]/div[1]/div[2]/div/div[3]/div[1]/div[1]/div[2]/div/div/input"));
            inputFrom.Clear();
            inputFrom.SendKeys(locationFrom);
        }

        public void TargetLocationInput(string locationTo)
        {
            var inputTo = driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[3]/div[1]/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/input"));
            inputTo.Clear();
            inputTo.SendKeys(locationTo);
        }

        public void ClickRoute()
        {
            driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/button/img")).Click();
        }
        
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);            
        }

        public void ClickOnFoot()
        {
            driver.FindElement(By.XPath("/html/body/jsl/div[3]/div[9]/div[3]/div[1]/div[2]/div/div[2]/div/div/div[1]/div[4]/button/img")).Click();
        }
     
        public void ClickModal()        {

            var modal = driver.SwitchTo().Frame(0);
            modal.FindElement(By.XPath("//*[@id='introAgreeButton']/span/span")).Click();
        }

    }
}
