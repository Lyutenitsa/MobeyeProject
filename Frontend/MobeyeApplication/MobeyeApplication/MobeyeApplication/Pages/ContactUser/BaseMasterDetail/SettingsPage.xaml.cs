using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobeyeApplication.Pages.ContactUser.BaseMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private bool hasPersonalCode = Preferences.Get("hasPersonalCode", false);
        private string currentPersonalCode = Preferences.Get("personalCode", "");
        private string newPersonalCode = "";
        private string confirmedNewPersonalCode = "";
        public SettingsPage()
        {
            InitializeComponent();
            lbCancel.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => OnCancelLabelClicked()) });
            lbCancel2.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => OnCancelLabelClicked()) });
            if (hasPersonalCode == true)
            {
                ChangeCodeCard.IsVisible = true;
                AddNewCodeCard.IsVisible = false;
            }
            else
            {
                AddNewCodeCard.IsVisible = true;
                changedCode.IsVisible = false;
            }
        }
        void SetPersonalCode(object sender, EventArgs args)
        {
            /*AddNewCodeCard.IsVisible = true;
            changedCode.IsVisible = false;*/
            newPersonalCode = newCode.Text;
            confirmedNewPersonalCode = confirmedNewCode.Text;
            if (newPersonalCode.Equals(confirmedNewPersonalCode))
            {
                hasPersonalCode = true;
                currentPersonalCode = newPersonalCode;
                //we force the property save
                Preferences.Set("hasPersonalCode", true);
                Preferences.Set("personalCode", currentPersonalCode);
                App.Current.MainPage = new ContactMasterDetailPage();
                // var cc = DisplayAlert($"Your current personal code is : {currentPersonalCode}! Do you have personal code? {hasPersonalCode}", "Okay", "Nope");

            }
        }
        void ChangePersonalCode(object sender, EventArgs args)
        {
            /* ChangeCodeCard.IsVisible = true;
             AddNewCodeCard.IsVisible = false;*/
            confirmedNewPersonalCode = confirmedChangedCode.Text;
            newPersonalCode = changedCode.Text;
            if (hasPersonalCode && currentCode.Text.Equals(currentPersonalCode))
            {
                if (confirmedNewPersonalCode.Equals(newPersonalCode))
                {
                    currentPersonalCode = newPersonalCode;
                }
            }
        }
        void OnCancelLabelClicked()
        {
            App.Current.MainPage = new ContactMasterDetailPage();
        }
    }
}