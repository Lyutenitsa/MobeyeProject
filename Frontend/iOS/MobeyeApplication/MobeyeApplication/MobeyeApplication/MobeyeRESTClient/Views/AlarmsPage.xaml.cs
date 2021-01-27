﻿using MobeyeApplication.MobeyeRESTClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobeyeApplication.MobeyeRESTClient;
using MobeyeApplication.MobeyeRESTClient.JSON_objects;

namespace MobeyeApplication.MobeyeRESTClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmsPage : ContentPage
    {
        public AlarmsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var content = await AlarmRepo.alarmServiceClient.GetAllAlarms();
            if (content == null)
            {
                await DisplayAlert("Alert", "Something went wrong", "Ok");
            }
            else
            {
                AlarmView.ItemsSource = content;
                #region old code
                /*GetPrivateKey();
            }

            public async void GetPrivateKey()
            {
                string requestURI = "https://www.api.mymobeye.com/api/registerphone";
                HttpClient client = HttpHelper.CreateClient();

                var regPhone = new RegPhone("bbbb2222", "22222");            
                var responce = await client.PostAsync(requestURI, HttpHelper.ObjectToHttpContent(regPhone));

                var resString = await responce.Content.ReadAsStringAsync();
                List<string> idk = new List<string>();


                for(int i = 0; i<=0; i++)
                {
                    AlarmView.ItemsSource = idk;
    >>>>>>> MobeyeRestClient*/
                #endregion
            }
        }
    }   
}