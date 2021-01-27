using MobeyeApplication.MobeyeRESTClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
        private async void OnRegisterButtonClicked(object sender, EventArgs args)
        {
            var smsCode = SMSCode.Text;
            var imei = GetIMEInumber(smsCode);

            var resRegister = await API_Services.serviceClient.Register(imei, smsCode);
            if (resRegister == null)
            {
                await DisplayAlert("Alert", "Something went wrong.Try again", "Ok");
            }
            else
            {
                string privateKey = Preferences.Get("registerPrivateKey", "pkaaaa1111");

                if (privateKey != null)
                {
                    var resCheckAuth = await API_Services.serviceClient.CheckAuthorization(imei, privateKey);
                    switch (resCheckAuth.UserRole)
                    {
                        case "Account":
                            if (privateKey.Equals("pkaaaa1111")) // the one that has devices
                            {
                                App.Current.MainPage = new AccountUser.BaseMasterDetail.BasePage();
                            }
                            else
                            {
                                App.Current.MainPage = new CallKeyUser.CallKeyMainPage();
                            }
                            break;
                        case "Standard": // Contact user
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
            /*var smsCode = Convert.ToInt32(SMSCode.Text);
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
            }*/
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

        void OnUser1ButtonClicked(object sender, EventArgs args)
        {
            //App.Current.MainPage = new LoginPageAccUser();
            App.Current.MainPage = new LoginPageAccUser();
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