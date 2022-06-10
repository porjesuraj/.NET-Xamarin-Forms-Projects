using navigation.Models;
using navigation.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace navigation.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage()
        {
            InitializeComponent();

            _activity = GetActivities();

            activityList.ItemsSource = _activity;

        }
        private ObservableCollection<Activity> _activity;

        ObservableCollection<Activity> GetActivities()
        {
            var activity = new ObservableCollection<Activity>
             {
               
                 new Activity{UserId=1,Description = "My name is Jenny Dalby" },
                 new Activity{UserId=2, Description = "My name is Jonv" },
                 new Activity{UserId=3,  Description = "My name is RachelMartin"},
                 new Activity{ UserId=4,  Description = "My name is Nivan Jay"},
                 new Activity{ UserId=5,Description = "My name is SanazZ"},
                new Activity { UserId = 6, Description = "NextLab started following you." },
                new Activity { UserId = 7, Description = "Your Facebook friend Alex B is on Instagram." },
                new Activity { UserId = 8, Description = "Your Facebook friend Tara Chang is on Instagram." },
                new Activity { UserId = 9, Description = "Your Facebook friend Tom K is on Instagram." },

             };
         

            return activity;
        }

        private async void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var activity = e.SelectedItem as Activity;

           
           await Navigation.PushAsync(new UserProfilePage(activity.UserId));

            

        }
    }
}