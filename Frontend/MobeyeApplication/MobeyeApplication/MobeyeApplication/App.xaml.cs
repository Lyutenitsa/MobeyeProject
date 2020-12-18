using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobeyeApplication.Pages;
using MobeyeApplication.MobeyeRESTClient.Data;
using MobeyeApplication.MobeyeRESTClient.Views;

namespace MobeyeApplication
{
    public partial class App : Application
    {
        public static AlarmManager alarmManager { get; private set; }
        public App()
        {
            //MainPage = new LoginPage();
            MainPage = new NavigationPage(new AlarmsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
