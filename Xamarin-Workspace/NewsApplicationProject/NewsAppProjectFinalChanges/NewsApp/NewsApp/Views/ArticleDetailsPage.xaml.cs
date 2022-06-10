using Xamarin.Forms;

namespace NewsApp.Views
{
    public partial class ArticleDetailsPage : ContentPage
    {
        public ArticleDetailsPage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, System.EventArgs e)
        {
            await imageButton.ScaleTo(1.3, 200, Easing.BounceIn);
            await imageButton.ScaleTo(1, 200, Easing.BounceOut);
        }

        private async void ImageButton_Clicked_2(object sender, System.EventArgs e)
        {
            await imageButton2.ScaleTo(1.3, 200, Easing.BounceIn);
            await imageButton2.ScaleTo(1, 200, Easing.BounceOut);
        }
    }
}
