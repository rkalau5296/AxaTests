using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AxaTests
{
    [TestClass]
    public class SWAPITestSuite
    {
        [TestMethod]
        public void FindTatooine()
        {
            People people = new People();                        

            Planets planets = new Planets();           

            Assert.AreEqual(planets.GetPlanets().Results[0].Url, people.GetPeople().Results[0].Homeworld);

            Assert.AreEqual("Tatooine", planets.GetPlanets().Results[0].Name);            

            Assert.AreEqual(planets.GetPlanets().Results[0].Name, planets.GetTatooine().Name);

        }
    }
}
