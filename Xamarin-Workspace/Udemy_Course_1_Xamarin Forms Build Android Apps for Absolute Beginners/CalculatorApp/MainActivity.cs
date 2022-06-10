using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;

namespace CalculatorApp
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

            ImageView img = FindViewById<ImageView>(Resource.Id.imageView1);

            TextView txt1 = FindViewById<TextView>(Resource.Id.textView1);

            EditText edit = FindViewById<EditText>(Resource.Id.editText1);

            Button btn = FindViewById<Button>(Resource.Id.button1);

            TextView txt2 = FindViewById<TextView>(Resource.Id.textView2);

            double Area, Perimeter,R;
            btn.Click += (s, o) =>
            {
                if (edit.Text.Length > 0)
                {
                    R = double.Parse(edit.Text);
                    Area = Math.Pow(R, 2) * Math.PI;

                    Perimeter = 2 * Math.PI * R;

                    txt2.Text = Convert.ToString("the Area is " + Area + "\n\n" + "the perimeter is " + Perimeter);
                 } else
                {
                    Toast.MakeText(this, "Please enter radius ", ToastLength.Long).Show();
                }


            };



        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}