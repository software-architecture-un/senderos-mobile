﻿using System;
using Xamarin.Forms;

namespace SenderosMobile
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void BackClicked(object sender, EventArgs e)
        {
            LandingView landingView = new LandingView();
            Application.Current.MainPage = landingView;
        }

        private void LoginClicked(object sender, EventArgs e)
        {
            MainMasterDetailView mainView = new MainMasterDetailView();
            Application.Current.MainPage = mainView;
        }
    }
}