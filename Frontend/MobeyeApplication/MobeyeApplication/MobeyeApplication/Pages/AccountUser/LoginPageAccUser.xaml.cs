using MobeyeApplication.Pages.AccountUser;
using MobeyeApplication.Pages.AccountUser.BaseMasterDetail;
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
    public partial class LoginPageAccUser : ContentPage
    {
        public LoginPageAccUser()
        {
            InitializeComponent();
        }

        private void OnLoginBtnClicked(object sender, EventArgs e)
        {
            // Go to main menu of user 1
            //DisplayAlert("Test", "Login Successful!", "Cancel");
            //App.Current.MainPage = new BasePage();
            App.Current.MainPage = new BasePage();
        }
    }
}