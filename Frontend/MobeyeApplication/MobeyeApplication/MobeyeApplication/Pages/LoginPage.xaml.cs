using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobeyeApplication.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void OnRegisterButtonClicked(object sender, EventArgs args)
        {
            var smsCode = Convert.ToInt32(SMSCode.Text);
            if (smsCode == 1234)
            {
                App.Current.MainPage = new AccountUser.BaseMasterDetail.BasePage();
            }
            else if (smsCode == 0000)
            {
                App.Current.MainPage = new CallKeyUser.CallKeyMainPage();
            }
            else if (smsCode == 1111)
            {
                App.Current.MainPage = new WelcomePage();
            }
            else if (smsCode == 9999)
            {
                App.Current.MainPage = new ContactUser.BaseMasterDetail.ContactMasterDetailPage();
            }
            else
            {
                DisplayAlert("Please enter a valid SMS Code", "Yes", "No");
            }


        }
        void OnUser1ButtonClicked(object sender, EventArgs args)
        {
            //App.Current.MainPage = new LoginPageAccUser();
            App.Current.MainPage = new MobeyeRESTClient.Views.AlarmsPage();
        }

        void OnUser2ButtonClicked(object sender, EventArgs args)
        {
            //App.Current.MainPage = new LoginPageAccUser();
            App.Current.MainPage = new CallKeyUser.CallKeyMainPage();
        }

        void OnUser3ButtonClicked(object sender, EventArgs args)
        {
            //App.Current.MainPage = new LoginPageAccUser();
            App.Current.MainPage = new CallKeyUser.CallKeyMainPage();
        }
    }
}