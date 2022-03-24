using AxaTests.ApiService;
using AxaTests.Dto;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AxaTests
{
    public class People : RestRequestService
    {
        public PeopleDTO GetPeople(string path)       
        {
            var content = RestRequest(path).Content;
            var people = JsonConvert.DeserializeObject<PeopleDTO>(content);
            return people;         
        }
    }
}
