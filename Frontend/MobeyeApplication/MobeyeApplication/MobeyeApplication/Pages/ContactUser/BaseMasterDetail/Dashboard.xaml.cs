using MobeyeApplication.MobeyeRESTClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobeyeApplication.Pages.ContactUser.BaseMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        List<string> selectOptions;
        public Dashboard()
        {
            InitializeComponent();
            selectOptions = new List<string>();
            selectOptions.Add("All");
            selectOptions.Add("By Priority");
            select.ItemsSource = selectOptions;
        }
        protected async override void OnAppearing()
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
            }
        }
        async void OnConfirmAlarmButtonClickedAsync(object sender, EventArgs args)
        {
            await RespondToAlarm("Confirmed");
        }
        async void OnDenyAlarmButtonClicked(object sender, EventArgs args)
        {
            await RespondToAlarm("Denied");
        }
        public async Task RespondToAlarm(string response)
        {
            var privateKey = Preferences.Get("Private_Key", "");
            var content = await API_Services.serviceClient.MessageStatus("aaaa1111", 1, response, "pkaaaa1111");
            if (content == null)
            {
                await DisplayAlert("Alert", "Something went wrong! Please try again.", "Ok");
            }
            else if (response == "Confirmed")
            {
                await DisplayAlert("", "The Alarm was Confirmed", "OK");
            }
            else if (response == "Denied")
            {
                await DisplayAlert("", "The Alarm was Denied", "OK");
            }
            else
            {
                await DisplayAlert("", "Please try again", "OK");
            }

        }


    }
}