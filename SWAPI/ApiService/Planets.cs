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
    
        public PlanetsDTO GetPlanets(string path)
        {
            var content = RestRequest(path).Content;
            var planets = JsonConvert.DeserializeObject<PlanetsDTO>(content);
            return planets;
        }
        
    }
}
