using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobeyeApplication.MobeyeRESTClient;
using MobeyeApplication.MobeyeRESTClient.Data;
using MobeyeApplication.MobeyeRESTClient.Responses;

namespace MobeyeApplication.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void OnRegisterButtonClicked(object sender, EventArgs args)
        {
            var smsCode = Convert.ToInt32(SMSCode.Text);
            var imei = GetIMEInumber();

            var resRegister = await API_Services.serviceClient.Register(imei, smsCode.ToString());
            var privateKey = resRegister.PrivateKey;

            if (privateKey != null)
            {
                var resCheckAuth = await API_Services.serviceClient.CheckAuthorization(imei, privateKey);
                switch (resCheckAuth.UserRole)
                {
                    case "Account":
                        App.Current.MainPage = new AccountUser.BaseMasterDetail.BasePage();
                        break;
                    case "Contact":
                        App.Current.MainPage = new ContactUser.BaseMasterDetail.ContactMasterDetailPage();
                        break;
                    case "CallKey":
                        App.Current.MainPage = new CallKeyUser.CallKeyMainPage();
                        break;
                    default:
                        await DisplayAlert("Alert", "Something went wrong", "Ok");
                        break;
                }
            }
            else
            {
                await DisplayAlert("Authentication Error", "Please enter a valid SMS Code", "Ok");
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

        string GetIMEInumber()
        {
            // needs to be implemented
            return "aaaa1111";
        }
    }
}