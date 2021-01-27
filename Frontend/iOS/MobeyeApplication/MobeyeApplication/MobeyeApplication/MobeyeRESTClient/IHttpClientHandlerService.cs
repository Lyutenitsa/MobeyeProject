using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MobeyeApplication.MobeyeRESTClient
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
