using AxaTests.ApiService;
using AxaTests.Dto;
using AxaTests.SWAPI.ApiService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxaTests.Tests
{
    [TestClass]
    public class FindingCharactersHomeworldTestsSuite
    {
        readonly RestService<PeopleDTO> restServicePeople = new();
        readonly RestService<PeopleResult> restServicePeopleResult = new();

        [TestMethod]
        public void FindLukeSkywalkerHomeworld()
        {
            object lukeSkywalkerHomeworld = restServicePeople.GetData("people", "Luke Skywalker");
            object lukesPlanet = restServicePeopleResult.FindPlanetName((Uri)lukeSkywalkerHomeworld);
            Assert.AreEqual("Tatooine", lukesPlanet.ToString());
        }
        [TestMethod]
        public void FindOwenLarsHomeworld()
        {
            object owenLarsHomeworld = restServicePeople.GetData("people", "Owen Lars");
            object owenLarssPlanet = restServicePeopleResult.FindPlanetName((Uri)owenLarsHomeworld);
            Assert.AreEqual("Tatooine", owenLarssPlanet.ToString());
        }
        [TestMethod]
        public void FindChewbaccaHomeworld()
        {
            object chewbaccaHomeworld = restServicePeople.GetData("people", "Chewbacca");
            object chewbaccasPlanet = restServicePeopleResult.FindPlanetName((Uri)chewbaccaHomeworld);
            Assert.AreEqual("Kashyyyk", chewbaccasPlanet.ToString());
        }
        [TestMethod]
        public void FindAckbarHomeworld()
        {
            object ackbar = restServicePeople.GetData("people", "Ackbar");
            object ackbarsPlanet = restServicePeopleResult.FindPlanetName((Uri)ackbar);
            Assert.AreEqual("Mon Cala", ackbarsPlanet.ToString());
        }
        [TestMethod]
        public void FindShmiSkywalkerHomeworld()
        {
            object shmiSkywalker = restServicePeople.GetData("people", "Shmi Skywalker");
            object shmiSkywalkersPlanet = restServicePeopleResult.FindPlanetName((Uri)shmiSkywalker);
            Assert.AreEqual("Tatooine", shmiSkywalkersPlanet.ToString());
        }
        [TestMethod]
        public void FindSanHillHomeworld()
        {
            object sanHill = restServicePeople.GetData("people", "San Hill");
            object sanHillsPlanet = restServicePeopleResult.FindPlanetName((Uri)sanHill);
            Assert.AreEqual("Muunilinst", sanHillsPlanet.ToString());
        }        
    }
}
