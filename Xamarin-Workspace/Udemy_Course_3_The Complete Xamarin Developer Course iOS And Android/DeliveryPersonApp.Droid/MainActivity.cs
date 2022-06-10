using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using DeliveryPersonApp.Droid.Acitvities;
using DeliveryPersonApp.Droid.Model;
using SQLite;
using static Android.Provider.SyncStateContract;

namespace DeliveryPersonApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText emailEditText, passwordEditText;

        Button signinButton, registerBUtton;

        public static SQLiteAsyncConnection connect { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            CreateDb();
          
            SetContentView(Resource.Layout.LoginUser);

            emailEditText = FindViewById<EditText>(Resource.Id.emailInputEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordInputEditText);

            signinButton = FindViewById<Button>(Resource.Id.signInbutton);

            registerBUtton = FindViewById<Button>(Resource.Id.registerButton);

            signinButton.Click += SigninButton_Click;

            registerBUtton.Click += RegisterBUtton_Click;


            string email = Intent.GetStringExtra("email");

            string password = Intent.GetStringExtra("password");

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                emailEditText.Text = email;
                passwordEditText.Text = password;
            }


        }


        private async void CreateDb()
        {
            MainActivity.connect = new SQLiteAsyncConnection(Constants.DataBase.DbPath);

            if (connect != null)
            {
                await connect.CreateTableAsync<Users>();
                await connect.CreateTableAsync<Delivery>();
                await connect.CreateTableAsync<DeliveryPerson>();

                System.Console.WriteLine("database successfully created");

            }

        }

        private void RegisterBUtton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email", emailEditText.Text);
            StartActivity(intent);
        }

        private async void SigninButton_Click(object sender, System.EventArgs e)
        {
            var loginEmail = emailEditText.Text;
            var loginPassword = passwordEditText.Text;

            var result = await Users.Login(loginEmail, loginPassword);

            if (result)
            {
                Toast.MakeText(this, "Login Successful", ToastLength.Short).Show();

               Intent intent = new Intent(this, typeof(Acitvities.TabActivity));
               StartActivity(intent);

               Finish();

            }
            else
            {
                Toast.MakeText(this, "Login Details Doesnt Match", ToastLength.Short).Show();
            }

        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}