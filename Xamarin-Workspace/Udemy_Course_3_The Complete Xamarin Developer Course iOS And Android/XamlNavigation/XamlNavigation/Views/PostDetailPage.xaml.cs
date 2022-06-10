using Prism.Navigation;
using Xamarin.Forms;
using XamlNavigation.ViewModels;

namespace XamlNavigation.Views
{
    public partial class PostDetailPage : ContentPage
    {
        public PostDetailPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
          //  expLabel.Text =  (BindingContext as PostDetailPageViewModel).Experience;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
