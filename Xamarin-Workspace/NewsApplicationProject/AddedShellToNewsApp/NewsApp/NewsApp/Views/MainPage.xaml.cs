
using NewsApp.Common.Models;
using NewsApp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using Xamarin.Forms;

namespace NewsApp.Views
{
    public partial class MainPage
    {
        private Timer timer;

        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {

            timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds)
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



                int count = (headlineCarousel.ItemsSource as ObservableCollection<Article>).Count;

                if(headlineCarousel.Position == (count - 1))
                {
                    headlineCarousel.Position = 0;
                }else
                {
                    headlineCarousel.Position += 1;

                }


            });
        }

        protected override void OnDisappearing()
        {

            timer?.Dispose();
            base.OnDisappearing();
        }

       
         



         
      

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            (BindingContext as MainPageViewModel).CarouselItemTapped.Execute(e );
        }

        
    }
}
