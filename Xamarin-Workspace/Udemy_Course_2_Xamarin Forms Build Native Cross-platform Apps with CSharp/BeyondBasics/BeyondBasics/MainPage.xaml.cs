using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using BeyondBasics.Views;
namespace BeyondBasics
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResourceDictionaryPage());

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StyleExercisePage());

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var page = new MessageCenterPage();

            // page.SliderValueChanged += OnSliderValueChanged;

            MessagingCenter.Subscribe<MessageCenterPage, double>(this,Events.SliderValueChanged, OnSliderValueChanged);
            Navigation.PushAsync(page);

            MessagingCenter.Unsubscribe<MainPage>(this, Events.SliderValueChanged);
        }

        private void OnSliderValueChanged(MessageCenterPage source, double newValue)
        {
            message.Text =  "Slider value " +newValue.ToString();

          
        }
    }
}
