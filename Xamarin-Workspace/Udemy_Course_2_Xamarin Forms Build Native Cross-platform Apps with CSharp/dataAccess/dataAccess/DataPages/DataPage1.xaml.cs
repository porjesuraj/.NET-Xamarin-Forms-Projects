using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dataAccess.DataPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage1 : ContentPage
    {
        public DataPage1()
        {
            InitializeComponent();

            if(Application.Current.Properties.ContainsKey("Name"))
            title.Text = Application.Current.Properties["Name"].ToString();

            if (Application.Current.Properties.ContainsKey("NotificationsEnabled"))
                notify.On =(bool) Application.Current.Properties["NotificationsEnabled"];
        }

        private void OnChange(object sender, System.EventArgs e)
        {
            Application.Current.Properties["Name"] = title.Text;
            Application.Current.Properties["NotificationsEnabled"] = notify.On;

           // Application.Current.SavePropertiesAsync();
        }


       /* protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }*/
    }
}