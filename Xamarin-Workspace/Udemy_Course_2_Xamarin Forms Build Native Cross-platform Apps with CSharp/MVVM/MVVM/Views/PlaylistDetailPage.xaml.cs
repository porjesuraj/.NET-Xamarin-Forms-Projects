using MVVM.Model;
using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistDetailPage : ContentPage
    {
       // private PlaylistViewModel _playlist;
        public PlaylistDetailPage(PlaylistViewModel playlist)
        {
            BindingContext = playlist;
            InitializeComponent();

           // title.Text = _playlist.Title;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }
    }
}