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
    public class DataSuite
    {
        [TestMethod]
        public void GetData()
        {           
            RestService<PeopleDTO> restService = new();

            object lukeSkywalkerHomeworld = restService.GetData("people", "Luke Skywalker");
            object owenLarsHomeworld = restService.GetData("people", "Owen Lars");
            object chewbaccaHomeworld = restService.GetData("people", "Chewbacca");
            object ackbar = restService.GetData("people", "Ackbar");
            object shmiSkywalker = restService.GetData("people", "Shmi Skywalker");
            object sanHill = restService.GetData("people", "San Hill");

            RestService<PeopleResult> restService1 = new();

            object lukesPlanet = restService1.FindPlanetName((Uri)lukeSkywalkerHomeworld);
            object owenLarssPlanet = restService1.FindPlanetName((Uri)owenLarsHomeworld);
            object chewbaccasPlanet = restService1.FindPlanetName((Uri)chewbaccaHomeworld);
            object ackbarsPlanet = restService1.FindPlanetName((Uri)ackbar);
            object shmiSkywalkersPlanet = restService1.FindPlanetName((Uri)shmiSkywalker);
            object sanHillsPlanet = restService1.FindPlanetName((Uri)sanHill);



            Assert.AreEqual("Tatooine", lukesPlanet.ToString());
            Assert.AreEqual("Tatooine", owenLarssPlanet.ToString());
            Assert.AreEqual("Kashyyyk", chewbaccasPlanet.ToString());
            Assert.AreEqual("Mon Cala", ackbarsPlanet.ToString());
            Assert.AreEqual("Tatooine", shmiSkywalkersPlanet.ToString());
            Assert.AreEqual("Muunilinst", sanHillsPlanet.ToString());
        }
    }
}
