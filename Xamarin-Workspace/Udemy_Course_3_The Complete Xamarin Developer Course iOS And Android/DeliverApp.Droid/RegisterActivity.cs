using Android.App;
using Android.Content;
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
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText emailEditText, passwordEditText, confirmPasswordEditText;
        Button registerButton;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);

            registerButton = FindViewById<Button>(Resource.Id.registerUserButton);

            registerButton.Click += RegisterButton_Click;

            string email = Intent.GetStringExtra("email");


            emailEditText.Text = email;


        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {

            #region all code here 
          /*  try
            {
                if (!String.IsNullOrEmpty(emailEditText.Text) && !String.IsNullOrEmpty(passwordEditText.Text))
                {
                    if (passwordEditText.Text == confirmPasswordEditText.Text)
                    {
                        Users u = new Users
                        {
                            Email = emailEditText.Text,
                            Password = passwordEditText.Text
                        };

                        int row = await MainActivity.connect.InsertAsync(u);

                        if (row > 0)
                        {
                            Toast.MakeText(this, "Registered Successfully", ToastLength.Long).Show();

                            var intent = new Intent(this, typeof(MainActivity));
                            intent.PutExtra("email", emailEditText.Text);
                            intent.PutExtra("password", passwordEditText.Text);
                            StartActivity(intent);
                        }
                        else
                        {
                            Toast.MakeText(this, "Registeration Failed", ToastLength.Long).Show();
                            return;

                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Password don't Match", ToastLength.Short).Show();
                        return;
                    }
                }
                else
                {
                    Toast.MakeText(this, "Please Enter Register Detials", ToastLength.Short).Show();
                    return;
                }
            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
*/

            #endregion


            var result = await Users.Register(emailEditText.Text, passwordEditText.Text, confirmPasswordEditText.Text);

            if(result)
            {
                Toast.MakeText(this, "Registered Successfully", ToastLength.Long).Show();

                var intent = new Intent(this, typeof(MainActivity));
                intent.PutExtra("email", emailEditText.Text);
                intent.PutExtra("password", passwordEditText.Text);
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Registeration Failed", ToastLength.Long).Show();
            }
        }
    }
}