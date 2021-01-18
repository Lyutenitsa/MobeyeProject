using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Models
{
    public class NotificationService
    {

        public NotificationService()
        {

        }
        public void SendMessage(Alarm alarm)
        {
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mobeye-pushnotifications-firebase-adminsdk-oactd-243e359424.json")),
            });
            //Console.WriteLine("DefaultApp: "+defaultApp.Name); // "[DEFAULT]"
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    ["DeviceName"] = alarm.Devicename,
                    ["Location"] = alarm.Location
                },
                Notification = new Notification
                {
                    Title = alarm.Devicename,
                    Body = alarm.Alarmtext
                },
                Topic = "alarm"
            };
            var messaging = FirebaseMessaging.DefaultInstance;
            var result = messaging.SendAsync(message);
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"); //projects/myapp/messages/2492588335721724324
            Console.WriteLine(message); //projects/myapp/messages/2492588335721724324
        }
        
    }
}
