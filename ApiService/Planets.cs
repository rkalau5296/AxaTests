using AxaTests.ApiService;
using AxaTests.Dto;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AxaTests
{
    public class Planets : RestRequestService
    {
    
        public PlanetsDTO GetPlanets()
        {      
            return JsonConvert.DeserializeObject<PlanetsDTO>(RestRequest("planets/").Content);            
        }

        public PlanetResult GetTatooine() 
        {
            return JsonConvert.DeserializeObject<PlanetResult>(RestRequest("planets/1/").Content);            
        }
    }
}
