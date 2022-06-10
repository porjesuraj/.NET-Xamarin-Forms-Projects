using MVVM.Model;
using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistsPage : ContentPage
    {
       
        public PlaylistsPage()
        {
            InitializeComponent();

            ViewModel = new PlaylistsViewModel(new PageService());
        }

       
        /*  private void OnAddPlaylist(object sender, EventArgs e)
          {

              (BindingContext as PlaylistsViewModel).AddPlaylist();


          }*/

          void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
         {

             ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem); 
         }

        public PlaylistsViewModel ViewModel
        {
            get { return BindingContext as PlaylistsViewModel; }
            set { BindingContext = value; }
        }
    }
}