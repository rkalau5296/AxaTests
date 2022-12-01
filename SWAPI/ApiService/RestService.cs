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

        public object GetData(string typeOfData, string data)
        {
            int pageNumber = 1;
            object name = null;
            object homeworld = null;
            object url = null;
            while (homeworld == null && url == null)
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
                        var propertyValue = property.GetValue(result);

                        foreach (var value in propertyValue as IEnumerable)
                        {

                            Type elementType = value.GetType();
                            var valueProperties = elementType.GetProperties();
                            foreach (var valueProperty in valueProperties)
                            {
                                if (valueProperty.Name == "Name")
                                {
                                    name = valueProperty.GetValue(value);
                                    continue;
                                }
                                if (valueProperty.Name == "Homeworld")
                                {
                                    homeworld = valueProperty.GetValue(value);
                                    continue;
                                }
                                if (valueProperty.Name == "Url")
                                {
                                    url = valueProperty.GetValue(value);
                                    continue;
                                }
                            }
                            if (name as string == data)
                            {
                                break;
                            }
                            else
                            {
                                name = null;
                                homeworld = null;
                                url = null;
                            }

                        }
                    }
                }
                pageNumber++;
            }
            if (url != null && homeworld == null)
            { 
                return url; 
            }
            else
            {
                return homeworld;
            }
                
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
            foreach (var property in properties)
            {
                if (property.Name == "Name")
                {
                    value = property.GetValue(result);

                }

            }
            return value;
        }

    }
}
