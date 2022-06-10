
namespace FlexLayoutApp.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();


            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }
    }
}
