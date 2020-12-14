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
            PeopleResult specificCharacter = null;
            PlanetResult planetResult = null;

            int pageNumber = 0;
            PeopleDTO result;
            IRestResponse content;

            PlanetsDTO resultPlanets;
            IRestResponse restResponsePlanets;
           
            while (specificCharacter == null)
            {
                content = RestRequest(autoIncrementPageNumber(pageNumber));
                result = JsonConvert.DeserializeObject<PeopleDTO>(content.Content);

                PeopleResult[] people = result.Results;


                foreach (PeopleResult man in people)
                {
                    if (man.Name == name)
                    {
                        specificCharacter = man;
                        break;
                    }
                }
                pageNumber++;
                result = null;
                content = null;
            }
            pageNumber = 0;         
                       

            while(planetResult == null)
            {
                restResponsePlanets = RestRequest(autoIncrementPlanetPageNumber(pageNumber));
                resultPlanets = JsonConvert.DeserializeObject<PlanetsDTO>(restResponsePlanets.Content);
                PlanetResult[] planets = resultPlanets.Results;

                foreach (PlanetResult planet in planets)
                {
                    if (planet.Url == specificCharacter.Homeworld)
                    {
                        planetResult = planet;
                        break;
                    }

                }
                pageNumber++;
                resultPlanets = null;
                restResponsePlanets = null;
            }
                   

            return planetResult.Name;

        }

        public string autoIncrementPageNumber(int number)
        {
            number++;            
            return "people/?page=" + number.ToString();
        }

        public string autoIncrementPlanetPageNumber(int number)
        {
            number++;
            return "planets/?page=" + number.ToString();
        }
    }

   
}
