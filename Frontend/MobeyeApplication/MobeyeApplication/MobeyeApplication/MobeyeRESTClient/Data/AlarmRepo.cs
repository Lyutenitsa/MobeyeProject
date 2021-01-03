using MobeyeApplication.MobeyeRESTClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobeyeApplication.MobeyeRESTClient.Data
{
    public class AlarmRepo : IAlarm
    {
        private static AlarmRepo _alarmServiceClient;
        public IEnumerable<Alarm> Alarms;
        public static AlarmRepo alarmServiceClient
        {
            get
            {
                if (_alarmServiceClient == null)
                {
                    _alarmServiceClient = new AlarmRepo();
                }
                return _alarmServiceClient;
            }
        }
        private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient client;

        public AlarmRepo()
        {

            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.RESTURLAlarm);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));





        }
        public async Task<IEnumerable<Alarm>> GetAllAlarms()
        {
            /* Uri uri = new Uri(string.Format(Constants.RESTURLAlarm, string.Empty));*/

            var response = await client.GetAsync(client.BaseAddress);
            /*
              var responseRead = await response.Content.ReadAsStringAsync();
              var json = JsonConvert.DeserializeObject<IEnumerable<Alarm>>(responseRead);
              return json;*/

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                var jsoncontent = _serializer.Deserialize<IEnumerable<Alarm>>(json);
                return jsoncontent;
            }

        }

        public async Task<List<Alarm>> GetAllAlarmsByPriority(int priority)
        {

            throw new NotImplementedException();
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

        public Task GetAlarmById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
