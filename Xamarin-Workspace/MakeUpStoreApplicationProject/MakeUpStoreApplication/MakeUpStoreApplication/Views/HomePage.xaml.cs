using MakeUpStoreApplication.Common.Models;
using MakeUpStoreApplication.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using Xamarin.Forms;

namespace MakeUpStoreApplication.Views
{
    public partial class HomePage : ContentPage
    {
        private Timer timer;
        public HomePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            timer = new Timer(TimeSpan.FromSeconds(10).TotalMilliseconds)
            {
                AutoReset = true,
                Enabled = true
            };

            timer.Elapsed += Timer_Elapsed;


            base.OnAppearing();


        }

        

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                

                int count = (productCarousel.ItemsSource as ObservableCollection<MakeUp>).Count;
                if(count > 0)
                {
                    if (productCarousel.Position == (count - 1))
                    {
                        productCarousel.Position = 0;
                    }
                    else
                    {
                        productCarousel.Position += 1;

                    }
                }
               


            });
        }

        protected override void OnDisappearing()
        {

            timer?.Dispose();
            base.OnDisappearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           
                (BindingContext as HomePageViewModel).CarouselItemTapped.Execute(e);
            
        }
    }
}
