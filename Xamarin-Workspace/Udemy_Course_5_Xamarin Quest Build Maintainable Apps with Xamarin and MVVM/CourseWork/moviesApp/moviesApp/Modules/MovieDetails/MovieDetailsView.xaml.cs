using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace moviesApp.Modules.MovieDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsView : ContentPage
    {
        public MovieDetailsView(MovieDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await imageButton.ScaleTo(1.3, 200, Easing.BounceIn);
            await imageButton.ScaleTo(1, 200, Easing.BounceOut);

        }
    }
}