using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace MobeyeApplication.MobeyeRESTClient
{
    public static class HttpHelper
    {
        public static HttpClient CreateClient()
        {
            HttpClient client;
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            client = new HttpClient(httpClientHandler);
            return client;
        }

        public static StringContent ObjectToHttpContent(object input)
        {
            var jsonObject = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            return content;
        }
    }
}
