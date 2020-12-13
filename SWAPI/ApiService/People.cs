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
        public PeopleDTO GetPeople()       
        {
            return JsonConvert.DeserializeObject<PeopleDTO>(RestRequest("people/").Content);           
        }
    }
}
