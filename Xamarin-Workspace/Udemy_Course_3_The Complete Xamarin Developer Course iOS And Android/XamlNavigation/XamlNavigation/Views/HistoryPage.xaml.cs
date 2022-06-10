using Xamarin.Forms;
using XamlNavigation.ViewModels;

namespace XamlNavigation.Views
{
    public partial class HistoryPage : ContentPage
    { 
        public HistoryPage()
        {
            InitializeComponent();   
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
          postListView.ItemsSource = (BindingContext as HistoryPageViewModel).ListSource;
        }       
    }
}
