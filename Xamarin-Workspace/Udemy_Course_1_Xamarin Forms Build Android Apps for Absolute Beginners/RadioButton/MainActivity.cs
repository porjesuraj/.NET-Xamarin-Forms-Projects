using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;

using Android.Content;
using Android.Views;
using System;

namespace RadioButton
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Android.Widget.RadioButton rbs = FindViewById<Android.Widget.RadioButton>(Resource.Id.radioButton1);
           //  RadioButton rb1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            rbs.Click += RadioButtonClicked;
        }

        private void RadioButtonClicked(object sender, EventArgs e)
        {
            Android.Widget.RadioButton rb = (Android.Widget.RadioButton)sender;
                 Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
        }

      


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}