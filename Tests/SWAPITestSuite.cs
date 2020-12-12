using AxaTests.ApiService;
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

            Uri tatooineUri = planets.GetPlanets().Results[0].Url;
            Uri lukeTatooineUri = people.GetPeople().Results[0].Homeworld;
            string tatooine = planets.GetPlanets().Results[0].Name;            

            Assert.AreEqual(tatooineUri, lukeTatooineUri);

            Assert.AreEqual("Tatooine", tatooine);            

            Assert.AreEqual(tatooine, planets.GetTatooine().Name);

        }


        [TestMethod]

        public void DetermineIfLukesHomeworldIsTatooine()
        {
            RestRequestService restRequestService = new RestRequestService();            

            Assert.AreEqual("Tatooine", restRequestService.FindSpecificCharactersHomeworld("Luke Skywalker"));
        }
    }
}
