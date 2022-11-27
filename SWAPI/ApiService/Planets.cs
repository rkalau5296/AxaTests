using AxaTests.ApiService;
using AxaTests.Dto;
using Newtonsoft.Json;

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
