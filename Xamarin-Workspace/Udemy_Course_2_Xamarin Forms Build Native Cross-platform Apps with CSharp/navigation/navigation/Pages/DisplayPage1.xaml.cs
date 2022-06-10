using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace navigation.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayPage1 : ContentPage
    {
        public DisplayPage1()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
          var resp = await  DisplayAlert("Warning", "Are you sure?", "Yes","No");

            if (resp)
              await  DisplayAlert("Done", "It is done", "OK");
        
        
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var response =  await DisplayActionSheet("Contacts", "Cancel", "Delete", "New Contact", "Email", "Call", "Whatsapp");

               await DisplayAlert("Response", response, "OK");
        }
    }
}