using MobeyeApplication.MobeyeRESTClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobeyeApplication.MobeyeRESTClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmsPage : ContentPage
    {
        public AlarmsPage()
        {
            InitializeComponent();
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
    }
}