using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dataAccess
{
    public partial class App : Application
    {
        private const string TitleKey = "Name";
        private const string NotifyKey = "NotificationsEnabled";

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new NavigationPage(new MainPage())
            {
               BarBackgroundColor = Color.FromHex("E63528"),
                BarTextColor = Color.FromHex("FFFFFF")


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

        

       public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();
                
                return "";
            }
            set
            {
                Properties[TitleKey] = value;
            }
        }

        public bool Notification
        {
            get
            {
                if (Properties.ContainsKey(NotifyKey))
                    return (bool)Properties[NotifyKey];

                return false;
            }
            set
            {
                Properties[NotifyKey] = value;
            }
        }


    }
}
