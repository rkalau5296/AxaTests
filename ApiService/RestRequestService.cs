using AxaTests.Dto;
using Newtonsoft.Json;
using RestSharp;

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
    }
}
