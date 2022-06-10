using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("6437f1"),
                BarTextColor = Color.FromHex("f8f8f8")
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
