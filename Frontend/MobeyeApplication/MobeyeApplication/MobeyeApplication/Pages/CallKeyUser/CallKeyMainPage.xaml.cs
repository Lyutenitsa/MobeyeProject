using MobeyeApplication.MobeyeRESTClient.Data;
using MobeyeApplication.MobeyeRESTClient.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobeyeApplication.Pages.CallKeyUser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallKeyMainPage : ContentPage
    {


        public CallKeyMainPage()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var privateKey = Preferences.Get("Private_Key", "");
            var content = await API_Services.serviceClient.CheckAuthorization("bbbb2222", privateKey);
            var devices = content.Devices;
            if (content == null)
            {
                await DisplayAlert("Alert", "Something went wrong", "Ok");
            }
            else
            {

                DoorView.ItemsSource = content.Devices;



            }
        }
        void LogOutButtonClicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new LoginPage();
        }
        async void RefreshButtonClicked(object sender, EventArgs args)
        {
            await RefreshButtonClickedAsync();
        }
        async void OpenDoorButtonClicked(object sender, EventArgs args)
        {
            await OpenDoorAsync();
        }
        public async Task RefreshButtonClickedAsync()
        {
            var privateKey = Preferences.Get("Private_Key", "");
            var content = await API_Services.serviceClient.CheckAuthorization("bbbb2222", privateKey);
            var devices = content.Devices;
            if (content == null)
            {
                await DisplayAlert("Alert", "Something went wrong", "Ok");
            }
            else
            {


                DoorView.ItemsSource = content.Devices;
            }
        }
        public async Task OpenDoorAsync()
        {
            int doorId = Preferences.Get("Door_Id", 8166);
            string command = Preferences.Get("Command", "DO1");
            var privateKey = Preferences.Get("Private_Key", "");
            var content = await API_Services.serviceClient.SendCommand("bbbb2222", doorId, privateKey, command);
            if (content.StatusCode.Equals(HttpStatusCode.OK))
            {
                await DisplayAlert("Opening Door...", "The door will be open shortly!", "Ok");
            }
            else if (content.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                await DisplayAlert("No access", "You cannot open this door!", "Ok");
            }
            else
            {
                await DisplayAlert("Alert", "Something went wrong! Please try again.", "Ok");
            }
        }

    }
}