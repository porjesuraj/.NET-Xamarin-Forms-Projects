using Plugin.Permissions;
using Xamarin.Forms;

using Plugin.Geolocator;
using System;
using Plugin.Geolocator.Abstractions;

using Plugin.Permissions.Abstractions;

namespace XamlNavigation.Views
{
    public partial class MapPage : ContentPage
    {

        private bool hasLocationPermission = false;

        [System.Obsolete]
        public MapPage()
        {
            InitializeComponent();

            GetPerimissions();
        }


        protected   override async void OnAppearing()
        {
            base.OnAppearing();

            if(hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;

               await locator.StartListeningAsync(TimeSpan.Zero,100);
            }
            GetLocation();

        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();

           await CrossGeolocator.Current.StopListeningAsync();

            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged; 
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {

            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission )
            {
                var locator = CrossGeolocator.Current;

                var position = await locator.GetPositionAsync();
                MoveMap(position);
            }

        }

        private void MoveMap(Position position)
        {
          
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            firstMap.MoveToRegion(span);
        }

        [System.Obsolete]
        private async void GetPerimissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);

              //  var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {

                   // status = await Permission.RequestAsync<Permissions.LocationWhenInUse>();

                     if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))

                     {
                         await DisplayAlert("Need your location", "We need  to access your location", "OK");
                     }

                 
                   // var results = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                   var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);

                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];

                 

                }
                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;

                    firstMap.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location denied", "Location access Denied", "OK");
                }
            }
            catch (System.Exception ex)
            {
               await DisplayAlert("Error", ex.Message, "OK");
                throw;
            }

           


               
        }
    }
}
