using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace MobeyeApplication.MobeyeRESTClient
{
    public static class Constants
    {



        //for backend connection
        public static string RESTURLAlarm = Device.RuntimePlatform == Device.Android ? "https://mobeye-api.conveyor.cloud/api/alarms" : "https://localhost:5001/api/alarms";
        public static string RESTURLUser = Device.RuntimePlatform == Device.Android ? "https://localhost:5001/api/accountusers/{0}/{1}" : "https://192.168.1.121/api/accountusers/{0}/{1}";

    }
}
