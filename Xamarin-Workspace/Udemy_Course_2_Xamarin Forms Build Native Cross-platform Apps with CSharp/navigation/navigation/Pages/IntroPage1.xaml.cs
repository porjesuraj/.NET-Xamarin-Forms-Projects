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
    public partial class IntroPage1 : ContentPage
    {
        public IntroPage1()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync(); 
            await Navigation.PopModalAsync(); 
        }

        protected override bool OnBackButtonPressed()
        {
              DisplayAlert("Back Button", " Disabled", "OK");
            return true;
        }
    }
}