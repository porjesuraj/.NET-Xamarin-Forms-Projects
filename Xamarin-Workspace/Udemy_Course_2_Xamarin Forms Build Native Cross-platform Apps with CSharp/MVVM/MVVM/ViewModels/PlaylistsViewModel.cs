using MVVM.Model;
using MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
   public class PlaylistsViewModel : BaseViewModel
    {

        private PlaylistViewModel _selectedPlaylist;
        private readonly IPageService _pageService;


        public ICommand AddPlaylistCommand { get; private set; }

        public ICommand SelectPlaylistCommand { get; private set; }

        public ObservableCollection<PlaylistViewModel> Playlists { get; set; } = new ObservableCollection<PlaylistViewModel>();


      

        public PlaylistViewModel SelectedPlaylist
        {
            get { return _selectedPlaylist; }
            set 
            {
                SetValue(ref _selectedPlaylist, value); 
            }
        }

       
        public PlaylistsViewModel(IPageService pageService)
        {
            _pageService = pageService;

            AddPlaylistCommand = new Command(AddPlaylist);


            SelectPlaylistCommand = new Command<PlaylistViewModel>( async vm => await SelectPlaylist(vm));
        }




        private void AddPlaylist()
        {
            var newPlaylist = "Playlist" + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });

          
        }

        private async Task SelectPlaylist(PlaylistViewModel playlist)
        {
          if (playlist == null)
                return;
            
                playlist.IsFavorite = !playlist.IsFavorite;

                SelectedPlaylist = null;

          await  _pageService.PushAsync(new PlaylistDetailPage(playlist));

             

        }
    }
}
