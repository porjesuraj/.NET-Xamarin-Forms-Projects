using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlEssential
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

              MainPage = new NavigationPage( new MainPage());
            //  MainPage = new oneGreetings();
            //MainPage = new DataBinding(); 
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
