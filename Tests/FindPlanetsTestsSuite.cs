using AxaTests.Dto;
using AxaTests.SWAPI.ApiService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AxaTests.Tests
{
    [TestClass]
    public class FindPlanetsTestsSuite
    {
        readonly RestService<PlanetsDTO> restServicePlanets = new();
        readonly RestService<PlanetResult> restServicePlanetResult = new();
        [TestMethod]
        public void FindTatooine()
        {
            object tatooine = restServicePlanets.GetData("planets", "Tatooine");
            object planetName = restServicePlanetResult.FindPlanetName((Uri)tatooine);
            Assert.AreEqual("Tatooine", planetName.ToString());
        }
        [TestMethod]
        public void FindKamino()
        {
            object kamino = restServicePlanets.GetData("planets", "Kamino");
            object planetName = restServicePlanetResult.FindPlanetName((Uri)kamino);
            Assert.AreEqual("Kamino", planetName.ToString());
        }
        [TestMethod]
        public void FindUtapau()
        {
            object utapau = restServicePlanets.GetData("planets", "Utapau");
            object planetName = restServicePlanetResult.FindPlanetName((Uri)utapau);
            Assert.AreEqual("Utapau", planetName.ToString());
        }
        [TestMethod]
        public void FindKashyyyk()
        {
            object kashyyyk = restServicePlanets.GetData("planets", "Kashyyyk");
            object planetName = restServicePlanetResult.FindPlanetName((Uri)kashyyyk);
            Assert.AreEqual("Kashyyyk", planetName.ToString());
        }
        [TestMethod]
        public void FindSaleucami()
        {
            object saleucami = restServicePlanets.GetData("planets", "Saleucami");
            object planetName = restServicePlanetResult.FindPlanetName((Uri)saleucami);
            Assert.AreEqual("Saleucami", planetName.ToString());
        }
        [TestMethod]
        public void FindChandrila()
        {
            object chandrila = restServicePlanets.GetData("planets", "Chandrila");
            object planetName = restServicePlanetResult.FindPlanetName((Uri)chandrila);
            Assert.AreEqual("Chandrila", planetName.ToString());
        }

        [TestMethod]
        public void FindCerea()
        {
            object cerea = restServicePlanets.GetData("planets", "Cerea");
            object planetName = restServicePlanetResult.FindPlanetName((Uri)cerea);
            Assert.AreEqual("Cerea", planetName.ToString());
        }

    }
}
