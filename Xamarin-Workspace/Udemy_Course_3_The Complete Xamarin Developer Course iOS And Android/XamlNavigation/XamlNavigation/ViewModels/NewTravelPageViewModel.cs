using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using XamlNavigation.Logic;
using XamlNavigation.Models;

namespace XamlNavigation.ViewModels
{
    public class NewTravelPageViewModel : BindableBase, IPageLifecycleAware
    {

        private string _experience;
        public string Experienced
        {
            get { return _experience; }
            set { SetProperty(ref _experience, value); }


        }


        private Venue _selectedVenue;
        public Venue SelectedVenueInList
        {
            get { return _selectedVenue; }
            set { SetProperty(ref _selectedVenue, value); }
        }







        private IPageDialogService _pageDialogService;


        private INavigationService _navigationService;
        public DelegateCommand SaveExperienceCommand { get; }
        public NewTravelPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService)
        {
            _pageDialogService = pageDialogService;
            SaveExperienceCommand = new DelegateCommand(ExecuteSaveExperience);

            _navigationService = navigationService;

        }

        private async void ExecuteSaveExperience()
        {
            try
            {
                var firstCategory = SelectedVenueInList.categories.FirstOrDefault();

                Post post = new Post
                {
                    Experience = Experienced,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name,
                    Address = SelectedVenueInList.location.address,
                    Distance = SelectedVenueInList.location.distance,
                    Latitude = SelectedVenueInList.location.lat,
                    Longitude = SelectedVenueInList.location.lng,
                    VenueName = SelectedVenueInList.name,
                    UserId = App.users.Id

                };


                      
                
                 //  await App.connect.CreateTableAsync<Post>();

              //  int rows = await App.connect.InsertAsync(post);
                int rows = await Post.Insert(post);
                if (rows > 0)
                    {
                       await _pageDialogService.DisplayAlertAsync("Success", "Experience successfully inserted", "Ok");

                      await  _navigationService.GoBackAsync();
                    }
                    else
                     await   _pageDialogService.DisplayAlertAsync("Failed", "Experience not inserted", "Ok");
                

            }
            catch (NullReferenceException )
            {
              await  _pageDialogService.DisplayAlertAsync("Warning", "Please Select Atleast one location", "Ok");

                
            }

            catch (Exception ex)
            {
             await   _pageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");

                
            }

           
         
           

        }

        [Obsolete]
        public async void OnAppearing()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await _pageDialogService.DisplayAlertAsync("Need Permission", "We will have to access your location", "Ok");
                    }

                    var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);


                    if (result.ContainsKey(Permission.Location))
                        status = result[Permission.Location];
                }
                if(status == PermissionStatus.Granted)
                {
                    var locator = CrossGeolocator.Current;

                    var position = await locator.GetPositionAsync();

                    var venuses = await Venue.GetVenues(position.Latitude, position.Longitude);

                    VenuesList = venuses;
                }else
                {
                    await _pageDialogService.DisplayAlertAsync("Failed", "Permission Denied", "Ok");

                }

            }
            catch (Exception ex)
            {

             await  _pageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");

               
            }

           
        }

        public void OnDisappearing()
        {
            
        }

        private List<Venue> venuesList;

        public List<Venue> VenuesList { get => venuesList; set => SetProperty(ref venuesList, value); }
    }
}
