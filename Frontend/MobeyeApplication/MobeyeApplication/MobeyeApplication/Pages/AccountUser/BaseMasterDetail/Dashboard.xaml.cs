using MobeyeApplication.MobeyeRESTClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobeyeApplication.Pages.AccountUser.BaseMasterDetail
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
    }
}