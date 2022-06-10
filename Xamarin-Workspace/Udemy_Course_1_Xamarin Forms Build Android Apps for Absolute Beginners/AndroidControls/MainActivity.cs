using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;

namespace AndroidControls
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    [System.Obsolete]
    public class MainActivity : AppCompatActivity
    //for list view
    //public class MainActivity : ListActivity

    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //Set our view from the "main" layout resource
            // SetContentView(Resource.Layout.activity_main);

            //  Android.Widget.LinearLayout layout = FindViewById<Android.Widget.LinearLayout>(Resource.Id.linearlayout); 

            #region HelloWorld code

            /*SetContentView(Resource.Layout.helloWorld);

            Android.Widget.EditText Et1 = FindViewById<Android.Widget.EditText>(Resource.Id.editText1);*/

            #endregion

            #region Button code
            /* SetContentView(Resource.Layout.button);

             Button btn = FindViewById<Button>(Resource.Id.button1);*/

            #endregion

            #region radiobutton code
            /* SetContentView(Resource.Layout.activity_main);

             Android.Widget.RadioButton rbs = FindViewById<Android.Widget.RadioButton>(Resource.Id.radioButton);

             rbs.Click += (s,e) =>
             {
                 Android.Widget.RadioButton rb = (Android.Widget.RadioButton)s;
                 Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
             };
 */


            #endregion


            #region Text

            /* SetContentView(Resource.Layout.text);

             TextView text1 = FindViewById<TextView>(Resource.Id.textView1);
             TextView text2 = FindViewById<TextView>(Resource.Id.textView2);
             TextView text3 = FindViewById<TextView>(Resource.Id.textView3);*/
            #endregion

            #region TextBox
            /*SetContentView(Resource.Layout.textBox);

            EditText text1 = FindViewById<EditText>(Resource.Id.editText1);
            EditText text2 = FindViewById<EditText>(Resource.Id.editText2);*/
            #endregion

            #region Checkbox code
            //SetContentView(Resource.Layout.checkbox);

            //Android.Widget.CheckBox ch = FindViewById<Android.Widget.CheckBox>(Resource.Id.checkbox);


            //ch.Click += (o, e) =>
            //{
            //    if (ch.Checked)
            //        Toast.MakeText(this, "good for you", ToastLength.Short).Show();
            //    else
            //        Toast.MakeText(this, "oh, how does it make you feel?", ToastLength.Short).Show();

            //};
            #endregion

            #region Toggle Button code

            //SetContentView(Resource.Layout.toggleButton);

            //ToggleButton tb = FindViewById<ToggleButton>(Resource.Id.toggleButton1);




            //tb.Click += (s, e) =>
            //{
            //    if (tb.Checked)
            //    {
            //        tb.SetMaxWidth(400);
            //        tb.SetMinHeight(100);

            //        Toast.MakeText(this, "Light On", ToastLength.Short).Show();


            //    }
            //    else
            //    {
            //        tb.SetMaxWidth(100);
            //        tb.SetMinHeight(400);

            //        Toast.MakeText(this, "Light Off", ToastLength.Short).Show();
            //    }

            //};

            #endregion

            #region ListVIew


            //string[] list = new string[] { "one", "two", "three", "four", "five", "one", "two", "three", "four", "five" };

            //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, list); 

            #endregion


            #region Layout code

            //SetContentView(Resource.Layout.linearLayout);
            //SetContentView(Resource.Layout.gridLayout);

            #endregion

        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}