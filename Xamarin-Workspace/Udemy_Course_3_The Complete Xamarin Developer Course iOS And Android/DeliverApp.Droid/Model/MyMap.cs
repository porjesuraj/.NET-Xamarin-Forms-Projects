using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// doesnt work due to null reference of Map
namespace DeliverApp.Droid.Model
{
    public class MyMap : Java.Lang.Object, IOnMapReadyCallback
    {
        public GoogleMap Map { get; set; } 

        public IntPtr Handle => Handled();

        private IntPtr Handled()
        {
            return IntPtr.Zero;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            Map = googleMap;


        }
    }
}