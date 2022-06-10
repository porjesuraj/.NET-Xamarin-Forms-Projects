﻿using System;
using TodoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage( new ToDoPage());
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
