using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobeyeApplication.Pages.AccountUser.BaseMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();

        }
        void OnEditProfileButtonClicked(object sender, EventArgs args)
        {
            //Device.OpenUri(new Uri("https://www.mymobeye.eu/"));
            Launcher.OpenAsync("https://www.mymobeye.eu/");
        }

    }
}