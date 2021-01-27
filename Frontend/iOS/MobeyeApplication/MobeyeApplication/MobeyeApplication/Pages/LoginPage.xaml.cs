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
using Xamarin.Essentials;

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

            var smsCode = SMSCode.Text;
            var imei = GetIMEInumber(smsCode);

            var resRegister = await API_Services.serviceClient.Register(imei, smsCode);
            var privateKey = Preferences.Get("registerPrivateKey", "pkaaaa1111");
            if (resRegister == null)
            {
                await DisplayAlert("Alert", "Something went wrong.", "Ok");
            }
            else
            {
                if (privateKey != null)
                {
                    var resCheckAuth = await API_Services.serviceClient.CheckAuthorization(imei, privateKey);
                    switch (resCheckAuth.UserRole)
                    {
                        case "Account":
                            if (privateKey.Equals("pkaaaa1111"))
                            {
                                App.Current.MainPage = new AccountUser.BaseMasterDetail.BasePage();
                            }
                            else
                            {
                                App.Current.MainPage = new CallKeyUser.CallKeyMainPage();
                            }
                            break;
                        case "Standard":
                            if (privateKey.Equals("pkdddd4444"))
                            {
                                App.Current.MainPage = new CallKeyUser.CallKeyMainPage();
                            }
                            else
                            {
                                App.Current.MainPage = new ContactUser.BaseMasterDetail.ContactMasterDetailPage();
                            }
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

        string GetIMEInumber(string smsCode)
        {
            switch (smsCode)
            {
                case "11111":
                    return "aaaa1111";
                case "22222":
                    return "bbbb2222";
                case "33333":
                    return "cccc3333";
                case "44444":
                    return "dddd4444";
                case "55555":
                    return "eeee5555";
                default:
                    return ":)";
            }
        }
        string GetRegisterNumber(string smsCode)
        {
            switch (smsCode)
            {
                case "11111":
                    return "pkaaaa1111";
                case "22222":
                    return "pkbbbb2222";
                case "33333":
                    return "pkcccc3333";
                case "44444":
                    return "pkdddd4444";
                case "55555":
                    return "pkeeee5555";
                default:
                    return ":)";
            }
        }
    }
}