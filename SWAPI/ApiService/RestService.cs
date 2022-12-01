using AxaTests.Dto;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AxaTests.SWAPI.ApiService
{
    public class RestService<T>
    {

        public object GetData(string typeOfData, string character)
        {
            int pageNumber = 1;
            object characterName = null;
            object characterHomeworld = null;
            
            while (characterHomeworld == null)
            {
                string path = typeOfData + "/?page=" + pageNumber;

                RestClient restClient = new();

                RestRequest restRequest = new("https://swapi.dev/api/" + path, Method.Get);
                restRequest.AddHeader("Accept", "application/json");
                restRequest.RequestFormat = DataFormat.Json;

                RestResponse restResponse = restClient.Execute(restRequest);
                var content = restResponse.Content;
                var result = JsonConvert.DeserializeObject<T>(content);

                Type type = result.GetType();
                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    if (property.Name == "Results")
                    {
                        var propValue = property.GetValue(result);

                        IEnumerable propValueArray = propValue as IEnumerable;

                        foreach (var person in propValue as IEnumerable)
                        {

                            Type elementType = person.GetType();
                            var personProperties = elementType.GetProperties();
                            foreach (var personProperty in personProperties)
                            {
                                if (personProperty.Name == "Name")
                                {
                                    characterName = personProperty.GetValue(person);
                                    continue;
                                }
                                if (personProperty.Name == "Homeworld")
                                {
                                    characterHomeworld = personProperty.GetValue(person);
                                    continue;
                                }
                            }
                            if(characterName as string == character)
                            {
                                break;
                            }
                            else
                            {
                                characterName = null;
                                characterHomeworld = null;
                            }

                        }
                    }
                }
                pageNumber++;
            }
            return characterHomeworld;
        }
        public object FindPlanetName(Uri path)
        {
            RestClient restClient = new();

            RestRequest restRequest = new(path, Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse restResponse = restClient.Execute(restRequest);
            var content = restResponse.Content;
            var result = JsonConvert.DeserializeObject<T>(content);

            Type type = result.GetType();
            var properties = type.GetProperties();
            object value = null;
            foreach ( var property in properties)
            {
                if(property.Name == "Name")
                {
                    value = property.GetValue(result);
                    
                }
                
            }
            return value;
        }

    }
}
