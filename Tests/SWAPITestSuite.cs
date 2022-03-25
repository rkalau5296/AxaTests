using AxaTests.ApiService;
using AxaTests.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AxaTests
{
    [TestClass]
    public class SWAPITestSuite
    {
        RestRequestService restRequestService = new RestRequestService();

        [TestMethod]
        public void FindTatooine()
        {          
            var planet = restRequestService.FindPlanet("Tatooine", null);
            Assert.AreEqual("Tatooine", planet.Name);            
        }        
        [TestMethod]
        public void FindCoruscant()
        {
            var planet = restRequestService.FindPlanet("Coruscant", null);
            Assert.AreEqual("Coruscant", planet.Name);
        }
        [TestMethod]
        public void FindIridonia()
        {
            var planet = restRequestService.FindPlanet("Iridonia", null);
            Assert.AreEqual("Iridonia", planet.Name);
        }
        
        [TestMethod]
        public void LukesHomeworldIsTatooine()
        {            
            var luke = restRequestService.FindMan("Luke Skywalker");            
            var planet = restRequestService.FindPlanet(null, luke.Homeworld);
            Assert.AreEqual("Tatooine", planet.Name);
        }

        [TestMethod]
        public void BobaFettsHomeworldIsKamino()
        {
            var bobaFett = restRequestService.FindMan("Boba Fett");
            var planet = restRequestService.FindPlanet(null, bobaFett.Homeworld);
            Assert.AreEqual("Kamino", planet.Name);
        }

        [TestMethod]
        public void BenQuadinarossHomeworldIsTund()
        {
            var benQuadinaros = restRequestService.FindMan("Ben Quadinaros");
            var planet = restRequestService.FindPlanet(null, benQuadinaros.Homeworld);
            Assert.AreEqual("Tund", planet.Name);
        }

        [TestMethod]
        public void TionMedonsHomeworldIsUtapau()
        {
            var tionMedon = restRequestService.FindMan("Tion Medon");
            var planet = restRequestService.FindPlanet(null, tionMedon.Homeworld);
            Assert.AreEqual("Utapau", planet.Name);
        }

        [TestMethod]
        public void SlyMooresHomeworldIsUmbara()
        {
            var slyMoore = restRequestService.FindMan("Sly Moore");
            var planet = restRequestService.FindPlanet(null, slyMoore.Homeworld);
            Assert.AreEqual("Umbara", planet.Name);
        }
    }
}
