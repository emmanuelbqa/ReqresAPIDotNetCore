using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace ReqresAPITestsNetCore
{
    public class APIHelpers<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseURL = "https://reqres.in/";

        public RestClient ConfigURL(string endpoint)
        {
            var actualurl = Path.Combine(baseURL, endpoint);
            var restClient = new RestClient(actualurl);
            return restClient;
        }

        public RestRequest CreatePostReq(dynamic payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            var json = JsonConvert.SerializeObject(payload);
            restRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateGetReq()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }
    }
}