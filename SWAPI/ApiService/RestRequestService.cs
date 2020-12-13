using AxaTests.Dto;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AxaTests.ApiService
{
    public class RestRequestService
    {
        public IRestResponse RestRequest(string recordNumber)
        {
            RestClient restClient = new RestClient("https://swapi.dev/");
            RestRequest restRequest = new RestRequest("api/" + recordNumber, Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = restClient.Execute(restRequest);

            return restResponse;
        }
        public string FindSpecificCharactersHomeworld(string name)
        {
            RestClient restClientPeople = new RestClient("https://swapi.dev/");
            RestRequest restRequestPeople = new RestRequest("api/people/", Method.GET);
            restRequestPeople.AddHeader("Accept", "application/json");
            restRequestPeople.RequestFormat = DataFormat.Json;

            IRestResponse restResponsePeople = restClientPeople.Execute(restRequestPeople);

            PeopleDTO result = JsonConvert.DeserializeObject<PeopleDTO>(restResponsePeople.Content);

            PeopleResult[] people = result.Results;

            PeopleResult specificCharacter = null;
            foreach(PeopleResult man in people)
            {
                if (man.Name == name)
                    specificCharacter = man;
                    break;
            }            
            
            RestClient restClientPlanets = new RestClient("https://swapi.dev/");
            RestRequest restRequestPlanets = new RestRequest("api/planets/", Method.GET);
            restRequestPlanets.AddHeader("Accept", "application/json");
            restRequestPlanets.RequestFormat = DataFormat.Json;

            IRestResponse restResponsePlanets = restClientPlanets.Execute(restRequestPlanets);

            PlanetsDTO resultPlanets = JsonConvert.DeserializeObject<PlanetsDTO>(restResponsePlanets.Content);

            PlanetResult[] planets = resultPlanets.Results;

            PlanetResult planetResult = null;

            foreach (PlanetResult planet in planets)
            {
                if (planet.Url == specificCharacter.Homeworld)
                    planetResult = planet;
                    break;
            }            

            return planetResult.Name;

        }
        
    }

   
}
