using AxaTests.Dto;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AxaTests.ApiService
{
    public class RestRequestService
    {
        public static IRestResponse RestRequest(string recordNumber)
        {
            RestClient restClient = new RestClient("https://swapi.dev/");
            RestRequest restRequest = new RestRequest("api/" + recordNumber, Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = restClient.Execute(restRequest);

            return restResponse;
        }       

        public static string AutoIncrementPageNumber(string page, int number)
        {
            number++;            
            return page + number.ToString();
        }        

        public PlanetResult FindPlanet(string planetName, Uri uri)
        {            
            Planets planets = new Planets();
            int pageNumber = 0;
            PlanetResult planetResult = null;

            while (planetResult == null)
            {
                var planetList = planets.GetPlanets(AutoIncrementPageNumber("planets/?page=", pageNumber));
                var results = planetList.Results;
                foreach (var result in results)
                {
                    if (result.Name == planetName || result.Url == uri)
                    {
                        planetResult = result;
                        break;
                    }
                }
                pageNumber++;
            }
            return planetResult;
        }        

        public PeopleResult FindMan(string man)
        {
            People people = new People();
            int pageNumber = 0;
            PeopleResult peopleResult = null;

            while(peopleResult == null)
            {
                var men = people.GetPeople(AutoIncrementPageNumber("people/?page=", pageNumber));
                var results = men.Results;
                foreach (var result in results)
                {
                    if (result.Name == man)
                    {
                        peopleResult = result;
                        break;
                    }
                }
                pageNumber++;
            }
            return peopleResult;
        }

    }

   
}
