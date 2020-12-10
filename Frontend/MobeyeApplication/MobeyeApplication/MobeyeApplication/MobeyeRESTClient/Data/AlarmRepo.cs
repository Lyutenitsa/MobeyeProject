using MobeyeApplication.MobeyeRESTClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobeyeApplication.MobeyeRESTClient.Data
{
    public class AlarmRepo : IAlarm
    {
        public HttpClient client;
        public List<Alarm> Alarms { get; private set; }
        public AlarmRepo()
        {

            //client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());

            client = new HttpClient();



        }
        public Task GetAlarmById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Alarm>> GetAllAlarms()
        {
            Alarms = new List<Alarm>();
            Uri uri = new Uri(string.Format(Constants.RESTURLAlarm, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Alarms = JsonConvert.DeserializeObject<List<Alarm>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Alarms;
        }

        public async Task<List<Alarm>> GetAllAlarmsByPriority(int priority)
        {
            Alarms = new List<Alarm>();
            //the uri is not exactly the same
            Uri uri = new Uri(string.Format(Constants.RESTURLAlarm, priority));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Alarms = JsonConvert.DeserializeObject<List<Alarm>>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Alarms;
        }

        public async Task UpdateAlarm(Alarm alarm)
        {
            Uri uri = new Uri(string.Format(Constants.RESTURLAlarm, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(alarm);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tAlarm successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

        }
    }
}
