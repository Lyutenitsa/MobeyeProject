using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Net;
using Microsoft.Extensions.Logging;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.IO;
using FirebaseAdmin.Messaging;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mobeye-pushnotifications-firebase-adminsdk-oactd-243e359424.json")),
            });
            Console.WriteLine("DefaultApp: "+defaultApp.Name); // "[DEFAULT]"
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    ["FirstName"] = "John",
                    ["LastName"] = "Doe"
                },
                Notification = new Notification
                {
                    Title = "Message Title",
                    Body = "Message Body"
                },

                //Token = "d3aLewjvTNw:APA91bE94LuGCqCSInwVaPuL1RoqWokeSLtwauyK-r0EmkPNeZmGavSG6ZgYQ4GRjp0NgOI1p-OAKORiNPHZe2IQWz5v1c3mwRE5s5WTv6_Pbhh58rY0yGEMQdDNEtPPZ_kJmqN5CaIc",
                Topic = "news"
            };
            var messaging = FirebaseMessaging.DefaultInstance;
            var result =  messaging.SendAsync(message);
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"); //projects/myapp/messages/2492588335721724324
            Console.WriteLine(message); //projects/myapp/messages/2492588335721724324


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();

                });

        
    }
}
