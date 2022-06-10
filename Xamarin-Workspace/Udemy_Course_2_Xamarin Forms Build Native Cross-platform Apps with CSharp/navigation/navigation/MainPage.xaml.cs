using navigation.MasterDetail;
using navigation.MasterPage;
using navigation.Pages;
using navigation.TabPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using navigation.Exercises;

namespace navigation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new IntroPage1());
            await Navigation.PushModalAsync(new IntroPage1());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPage());

        }

        [Obsolete]
        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MasterPage1()); 
        }

        private async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedPage1());

        }

        private async void Button_Clicked_5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarouselPage1());
        }

        private async void Button_Clicked_6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DisplayPage1());

        }

        private async void Button_Clicked_7(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExercisePage());

        }
    }
}
