using System.IO;
using RestSharp;
using RestSharp.Serialization.Json;

namespace APIAutomation
{
    public class APIHelper
    {
        public RestClient restClient;
        public RestRequest restRequest;
        string baseUrl = "http://api.zippopotam.us";

        /// <summary>
        /// Set Url for API
        /// </summary>
        /// <param name="endPoint">endpoint of API</param>
        /// <returns>rest client</returns>
        public RestClient SetUrl(string endPoint)
        {
            var url = Path.Combine(baseUrl, endPoint);
            var restClient = new RestClient(url);
            return restClient;
        }

        /// <summary>
        /// Creates Get Request
        /// </summary>
        /// <returns>Rest request</returns>
        public RestRequest CreateGetRequest()
        {
            RestRequest restRequest = new RestRequest(Method.GET);
            return restRequest;
        }
        /// <summary>
        /// Executes Rest Request 
        /// </summary>
        /// <param name="restClient">rest client URL</param>
        /// <param name="restRequest">Rest request</param>
        /// <returns>Returns response after executing the request</returns>
        public IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        /// <summary>
        /// Deserializes the Json Content of Rest Response
        /// </summary>
        /// <typeparam name="Root"></typeparam>
        /// <param name="response">rest reponse</param>
        /// <returns>returns Deserialized Json content</returns>
        public Root GetContent<Root>(IRestResponse response)
        {
            var content = response.Content;
            Root locationResponse = new JsonDeserializer().Deserialize<Root>(response);
            return locationResponse;
        }
    }
}
