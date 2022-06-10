using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Xamarin.Forms;
using XamlNavigation.Models;
using XamlNavigation.Services;

namespace XamlNavigation.ViewModels
{

    

    public class EssentialMapViewModel : BindableBase, IPageLifecycleAware
    {
        private bool hasLocationPermission = false;


        private readonly INavigationService navigationServices;

        private readonly IPageDialogService pageDialogServices;

       // private bool isShowUserEnabled;

       /* public bool IsShowUserEnabled 
        { get => isShowUserEnabled; 
         set => SetProperty(ref isShowUserEnabled, value); }
*/
        public Xamarin.Forms.Maps.Map Maps { get; set; }

        public ISQLService _sqlService { get; private set; }
        [Obsolete]
        public EssentialMapViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ISQLService SQLService)
        {
            Maps = new Xamarin.Forms.Maps.Map()
            {

                HorizontalOptions = LayoutOptions.FillAndExpand,

                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(10, 5)
               
                
               // IsShowingUser = IsShowUserEnabled 
            };

            navigationServices = navigationService;

            pageDialogServices = pageDialogService;

            _sqlService = SQLService;
            GetPermissions();
            
        }

        


        



        private async void GetLocation()
        {
            if (hasLocationPermission)
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
          //  firstMap.MoveToRegion(span);
        
        Maps.MoveToRegion(span);
        }

        [Obsolete]
        private async void GetPermissions()
        {
            try
            {

                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);

                //  var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))

                    {
                        await pageDialogServices.DisplayAlertAsync("Need your Location", "We need access for location", "OK");

                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);

                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];






                }


                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;

                   // IsShowUserEnabled = true;

                    Maps.IsShowingUser = true;

                    GetLocation();
                }else
                {
                    await pageDialogServices.DisplayAlertAsync("Location denied", "Location access Denied", "OK");
                }

            }
            catch (Exception ex )
            {
                await pageDialogServices.DisplayAlertAsync("Error",ex.Message , "OK");


                throw;
            }
        }

        public async void OnAppearing()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;

                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }
            GetLocation();


            //SQLiteAsyncConnection conn = _sqlService.GetConnection();

 

           //var posts = await _sqlService.LoadData(App.connect);
           // var posts = await  Post.LoadPost();
            var posts = await  Post.LoadUserPost();

            //await conn.CloseAsync();

            DisplayInMap(posts);
        }

        private void DisplayInMap(ObservableCollection<Post> posts)
        {


            foreach(var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SearchResult,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };

                    Maps.Pins.Add(pin);

                }
                catch (NullReferenceException ex)
                {
                    pageDialogServices.DisplayAlertAsync("Error", ex.Message, "Ok");
                   
                }
                catch (Exception ex)
                {
                    pageDialogServices.DisplayAlertAsync("Error", ex.Message, "Ok");
                    
                }
              
            }
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        public async void OnDisappearing()
        {
            

            await CrossGeolocator.Current.StopListeningAsync();

            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }
    }
}
