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
                content = RestRequest(autoIncrementPageNumber("people/?page=", pageNumber));
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
                
            }
            pageNumber = 0;         
                       

            while(planetResult == null)
            {
                restResponsePlanets = RestRequest(autoIncrementPageNumber("planets/?page=", pageNumber));
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
                
            }
                   

            return planetResult.Name;

        }

        public string autoIncrementPageNumber(string page, int number)
        {
            number++;            
            return page + number.ToString();
        }

    }

   
}
