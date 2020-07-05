using RestSharp;
using System;

namespace HandsOnTest.Data
{
    public class HttpRequestTemplate : IHttpRequestTemplate
    {
        private readonly IRestClient restClient;
        public HttpRequestTemplate(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public T Get<T>(string path) where T : class, new()
        {
            restClient.BaseUrl = new Uri(path);
            var request = new RestRequest(Method.GET);
            request.AddParameter("application/json", ParameterType.RequestBody);
            IRestResponse<T> response = restClient.Execute<T>(request);
            return response.Data;
        }
    }
}
