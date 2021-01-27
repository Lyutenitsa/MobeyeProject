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
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            lbGoToDashboard.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => OnMaybeLaterLabelClicked()) });
        }
        void OnSetLoginCodeButtonClicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new FirstTimeSettingsPage();
        }
        void OnMaybeLaterLabelClicked()
        {
            App.Current.MainPage = new AccountUser.BaseMasterDetail.BasePage();
        }
    }
}