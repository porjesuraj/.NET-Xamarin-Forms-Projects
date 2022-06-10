using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliverApp.Droid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity, IOnMapReadyCallback,ILocationListener
    {
        Button saveButton;
        EditText packageNameEditText;
        MapFragment mapFragment, destinationMapFragment;

        double latitude, longitude;
        LocationManager locationManager;

        GoogleMap originMaps, destinationMaps; 
        public void OnLocationChanged(Location location)
        {
            latitude = location.Latitude;
            longitude = location.Longitude;
            mapFragment.GetMapAsync(this);

            destinationMapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            if (this.originMaps == null)
            {
                this.originMaps = googleMap;
            }
            else
            {
                this.destinationMaps = googleMap;
            }


            MarkerOptions marker = new MarkerOptions();

            marker.SetPosition(new LatLng(latitude, longitude));

            marker.SetTitle("Your Location");

            googleMap.AddMarker(marker);

            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(latitude, longitude),10));
            
        }

        public void OnProviderDisabled(string provider)
        {
           
        }

        public void OnProviderEnabled(string provider)
        {
           
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.NewDelivery);

            saveButton = FindViewById<Button>(Resource.Id.button1);

            packageNameEditText = FindViewById<EditText>(Resource.Id.packageNameEditText);

            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapFragment);

            destinationMapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.destinationMapFragment);

            mapFragment.GetMapAsync(this);

           



            saveButton.Click += SaveButton_Click;


        }


        protected override void OnPause()
        {
            base.OnPause();

            locationManager.RemoveUpdates(this);
        }
        protected override void OnResume()
        {
            base.OnResume();


            locationManager = GetSystemService(Context.LocationService) as LocationManager;

            string provider = LocationManager.GpsProvider;

            if (locationManager.IsProviderEnabled(provider))
            {
                locationManager.RequestLocationUpdates(provider, 5000, 1, this);
            }

            var location = locationManager.GetLastKnownLocation(LocationManager.GpsProvider);

            latitude = location.Latitude;
            longitude = location.Longitude;

            mapFragment.GetMapAsync(this);

            destinationMapFragment.GetMapAsync(this);


        }


        private async void SaveButton_Click(object sender, EventArgs e)
        {
            MyMap originMap = new MyMap();

            MyMap destinationMap = new MyMap();

            mapFragment.GetMapAsync(originMap);

            destinationMapFragment.GetMapAsync(destinationMap);

            // var originLocation = originMap.Map.CameraPosition.Target;
            var originLocation =  this.originMaps.CameraPosition.Target;

            //  var destinationLocation = destinationMap.Map.CameraPosition.Target;

            var destinationLocation = this.originMaps.CameraPosition.Target;
            Delivery delivery = new Delivery()
            {
                Name = packageNameEditText.Text,
                Status = 0,
                OriginLatitude = originLocation.Latitude,
                OriginLongitude = originLocation.Longitude,
                DestinationLatitude = destinationLocation.Latitude,
                DestinationLongitude = destinationLocation.Longitude
            };

           var result = await Delivery.InsertDelivery(delivery);
            if(result)
            {
                Toast.MakeText(this, "Successfully added Delivery", ToastLength.Short).Show();

            }else
            {
                Toast.MakeText(this, "Failded to add Delivery", ToastLength.Short).Show();


            }
        }
    }
}