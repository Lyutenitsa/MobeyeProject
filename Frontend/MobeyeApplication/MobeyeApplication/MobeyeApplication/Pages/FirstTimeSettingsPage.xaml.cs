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
    public partial class FirstTimeSettingsPage : ContentPage
    {
        private bool hasPersonalCode = false;
        private string newPersonalCode = "";
        private string confirmedNewPersonalCode = "";
        private string currentPersonalCode = "";
        public FirstTimeSettingsPage()
        {
            InitializeComponent();
            lbCancel.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => OnCancelLabelClicked()) });
        }
        void OnCancelLabelClicked()
        {
            App.Current.MainPage = new AccountUser.BaseMasterDetail.BasePage();
        }
        void SetPersonalCode(object sender, EventArgs args)
        {

            newPersonalCode = newCode.Text;
            confirmedNewPersonalCode = confirmedNewCode.Text;
            if (newPersonalCode.Equals(confirmedNewPersonalCode))
            {
                hasPersonalCode = true;
                currentPersonalCode = newPersonalCode;
                //we force the property save
                Preferences.Set("hasPersonalCode", true);
                Preferences.Set("personalCode", currentPersonalCode);
                App.Current.MainPage = new AccountUser.BaseMasterDetail.BasePage();
                //var cc = DisplayAlert($"Your current personal code is : {currentPersonalCode}! Do you have personal code? {hasPersonalCode}", "Okay", "Nope");

            }
        }

    }
}