﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace images
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#2196F3"),
                BarTextColor = Color.White,
                
                
                

            };
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
