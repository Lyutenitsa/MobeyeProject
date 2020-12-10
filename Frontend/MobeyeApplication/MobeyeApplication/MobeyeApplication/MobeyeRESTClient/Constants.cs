using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobeyeApplication.MobeyeRESTClient
{
    public static class Constants
    {
        public static string RESTURLAlarm = Device.RuntimePlatform == Device.Android ? "https://192.168.1.121:45455/api/alarms/api/alarms/{0}" : "https://localhost:5001/api/alarms/{0}";
        public static string RESTURLUser = Device.RuntimePlatform == Device.Android ? "https://localhost:5001/api/accountusers/{0}/{1}" : "https://192.168.1.121/api/accountusers/{0}/{1}";

    }
}
