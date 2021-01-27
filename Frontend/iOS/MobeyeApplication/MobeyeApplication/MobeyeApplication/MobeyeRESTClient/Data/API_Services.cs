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

        public static HttpClient CreateClient()
        {
            HttpClient client;
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
           (message, cert, chain, errors) => { return true; };

            client = new HttpClient(httpClientHandler);
            return client;
        }

        public API_Services()
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
           (message, cert, chain, errors) => { return true; };

            client = new HttpClient(httpClientHandler);
            // client.BaseAddress = new Uri("https://www.api.mymobeye.com/api");
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
                var jsonContent = JsonConvert.SerializeObject(messageStatusRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var request = await client.PostAsync("https://www.api.mymobeye.com/api/messagestatus", content);
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
        // works fine

        public async Task<SendCommandResponse> SendCommand(string phoneId, int deviceId, string privateKey, string command)
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
                var jsonString = JsonConvert.SerializeObject(sendCommandRequest);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var request = await client.PostAsync("https://www.api.mymobeye.com/api/control", content);
                request.EnsureSuccessStatusCode();
                var returned_response = request.StatusCode;
                SendCommandResponse sendCommandResponse = new SendCommandResponse()
                {
                    StatusCode = returned_response
                };
                return sendCommandResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Check Authorization Request
        // for some reason -> returns null :) 
        public async Task<CheckAuthorizationResponse> CheckAuthorization(string phoneId, string privateKey)
        {
            try
            {
                CheckAuthorizationRequest checkAuthorizationRequest = new CheckAuthorizationRequest()
                {
                    PhoneId = phoneId,
                    PrivateKey = privateKey
                };
                var jsonString = JsonConvert.SerializeObject(checkAuthorizationRequest);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var request = await client.PostAsync("https://www.api.mymobeye.com/api/phoneauthorization", content);
                request.EnsureSuccessStatusCode();
                using (var stream = await request.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsonContent = _serializer.Deserialize<CheckAuthorizationResponse>(json);
                    // we set up in the preferences the user role and the second private key -> they will later be used to either display pages based on the role or in the requests
                    Preferences.Set("User_Role", jsonContent.UserRole);
                    Preferences.Set("Private_Key", jsonContent.PrivateKey);
                    foreach (Device d in jsonContent.Devices)
                    {
                        Preferences.Set("Door_Id", d.DeviceId);
                        Preferences.Set("Command", d.Command);
                    }
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
                var jsonString = JsonConvert.SerializeObject(registerRequest);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var request = await client.PostAsync("https://www.api.mymobeye.com/api/registerphone", content);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
