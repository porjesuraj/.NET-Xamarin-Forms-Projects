using Xamarin.Forms;

namespace XamlNavigation.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var assembly = typeof(LoginPage);

            iconImage.Source = ImageSource.FromResource("XamlNavigation.Assets.Images.roundLogo.png", assembly); 
            

            (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex("#4388CC");
        }
    }
}
