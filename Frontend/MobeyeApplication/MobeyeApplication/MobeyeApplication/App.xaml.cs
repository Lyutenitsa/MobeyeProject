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

        static MobeyeLocalDb database;

        public App()
        {
            MainPage = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("#29590D"),
                BarTextColor = Color.White
            };
        }
        public static MobeyeLocalDb Database
        {
            get
            {
                if (database == null)
                {
                    database = new MobeyeLocalDb();
                }
                return database;
            }
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
