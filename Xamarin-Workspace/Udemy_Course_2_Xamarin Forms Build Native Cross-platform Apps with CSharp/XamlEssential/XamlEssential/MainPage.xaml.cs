using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlEssential
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var dataPage = new DataBinding();
           await Application.Current.MainPage.Navigation.PushAsync(dataPage);
        }

        private  async void Button_Clicked_1(object sender, EventArgs e)
        {
            var greetings = new oneGreetings();
            await Application.Current.MainPage.Navigation.PushAsync(greetings); 
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var exercise = new ExerciseApp();
            await Application.Current.MainPage.Navigation.PushAsync(exercise);

        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            var hello = new Greetings();
            await Navigation.PushAsync(hello); 
        }
    }
}
