using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace MobeyeApplication.MobeyeRESTClient
{
    public static class Constants
    {
        //mobile local db
        public const string DatabaseFilename = "MobeyeLocalSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
           // open the database in read/write mode
           SQLite.SQLiteOpenFlags.ReadWrite |
           // create the database if it doesn't exist
           SQLite.SQLiteOpenFlags.Create |
           // enable multi-threaded database access
           SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        //for backend connection
        public static string RESTURLAlarm = Device.RuntimePlatform == Device.Android ? "https://192.168.1.121:45455/api/alarms/api/alarms/{0}" : "https://localhost:5001/api/alarms/{0}";
        public static string RESTURLUser = Device.RuntimePlatform == Device.Android ? "https://localhost:5001/api/accountusers/{0}/{1}" : "https://192.168.1.121/api/accountusers/{0}/{1}";

    }
}
