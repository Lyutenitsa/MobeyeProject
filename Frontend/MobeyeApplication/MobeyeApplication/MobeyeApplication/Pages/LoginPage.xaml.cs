﻿using System;
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