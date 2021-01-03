using MobeyeApplication.MobeyeRESTClient.Requests;
using MobeyeApplication.MobeyeRESTClient.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobeyeApplication.MobeyeRESTClient.Data
{
    /*This class would be responsible for handling the request/response pipeline with Mobeye API*/
    public class API_Services
    {
        private static API_Services _serviceClient;
        public static API_Services serviceClient
        {
            get
            {
                if (_serviceClient == null)
                {
                    _serviceClient = new API_Services();
                }
                return _serviceClient;
            }
        }
        private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient client;

        public API_Services()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://www.api.mymobeye.com/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Message Status request
        public async Task<MessageStatusResponse> MessageStatus(string phoneId, int messageId, string response, string privateKey)
        {
            try
            {
                MessageStatusRequest messageStatusRequest = new MessageStatusRequest()
                {
                    PhoneId = phoneId,
                    UniqueMessageId = messageId,
                    Response = response,
                    PrivateKey = privateKey
                };

                var content = new StringContent(JsonConvert.SerializeObject(messageStatusRequest), Encoding.UTF8, "application/json");
                var request = await client.PostAsync("messagestatus", content);
                request.EnsureSuccessStatusCode();
                var returned_response = await request.Content.ReadAsStringAsync();
                MessageStatusResponse messageStatusResponse = new MessageStatusResponse()
                {
                    Received = returned_response
                };
                return messageStatusResponse;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Send Command Request -> a.k.a Open Door for call key users
        public async Task SendCommand(string phoneId, string deviceId, string privateKey, string command)
        {
            try
            {
                SendCommandRequest sendCommandRequest = new SendCommandRequest()
                {
                    PhoneId = phoneId,
                    DeviceId = deviceId,
                    PrivateKey = privateKey,
                    Command = command
                };
                var content = new StringContent(JsonConvert.SerializeObject(sendCommandRequest), Encoding.UTF8, "application/json");
                var request = await client.PostAsync("control", content);
                request.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Check Authorization Request
        public async Task<CheckAuthorizationResponse> CheckAuthorization(string phoneId, string privateKey)
        {
            try
            {
                CheckAuthorizationRequest checkAuthorizationRequest = new CheckAuthorizationRequest()
                {
                    PhoneId = phoneId,
                    PrivateKey = privateKey
                };
                var content = new StringContent(JsonConvert.SerializeObject(checkAuthorizationRequest), Encoding.UTF8, "application/json");
                var request = await client.PostAsync("phoneauthorization", content);
                request.EnsureSuccessStatusCode();
                using (var stream = await request.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsonContent = _serializer.Deserialize<CheckAuthorizationResponse>(json);
                    // we set up in the preferences the user role and the second private key -> they will later be used to either display pages based on the role or in the requests
                    Preferences.Set("User_Role", jsonContent.UserRole);
                    Preferences.Set("Private_Key", jsonContent.PrivateKey);
                    return jsonContent;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //Register Request
        public async Task<RegisterReponse> Register(string phoneId, string code)
        {
            try
            {
                Register_Request registerRequest = new Register_Request()
                {
                    PhoneId = phoneId,
                    Code = code
                };
                var content = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");
                var request = await client.PostAsync("registerphone", content);
                request.EnsureSuccessStatusCode();
                using (var stream = await request.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsonContent = _serializer.Deserialize<RegisterReponse>(json);
                    Preferences.Set("registerPrivateKey", jsonContent.PrivateKey);
                    return jsonContent;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
