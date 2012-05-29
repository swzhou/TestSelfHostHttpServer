using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestAspnetWebAPI
{
    public class JsonClient
    {
        private const string MEDIA_TYPE = "application/json";
        private readonly string hostAddress;

        public JsonClient(string hostAddress)
        {
            this.hostAddress = hostAddress;
        }

        public HttpResponseMessage Get(string resourceName)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(String.Format("{0}/{1}", hostAddress, resourceName)),
                Method = HttpMethod.Get,
            };
            return Get(request);
        }

        public HttpResponseMessage Post(string resourceName, string content)
        {
            var request = new HttpRequestMessage
            {
                Content = new StringContent(content),
                RequestUri = new Uri(string.Format("{0}/{1}", hostAddress, resourceName)),
                Method = HttpMethod.Post
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(MEDIA_TYPE);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIA_TYPE));
            HttpResponseMessage response = new HttpClient().SendAsync(request).Result;
            return response;
        }

        private HttpResponseMessage Get(HttpRequestMessage request)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIA_TYPE));
            HttpResponseMessage response = new HttpClient().SendAsync(request).Result;
            return response;
        }
    }
}