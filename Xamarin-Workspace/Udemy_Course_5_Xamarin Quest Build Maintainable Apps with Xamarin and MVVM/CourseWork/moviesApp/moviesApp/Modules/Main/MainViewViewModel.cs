using moviesApp.Common.Base;
using moviesApp.Common.Navigation;
using moviesApp.Constants;
using moviesApp.Models;
using moviesApp.Modules.MovieDetails;
using moviesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace moviesApp.Modules.Main
{
    public class MainViewViewModel : BaseViewModel
    {
        private readonly INetworkService networkService;

        public ObservableCollection<MovieData> Items { get; set; }

        private MovieData selectedmovie;

        public MovieData SelectedMovie
        {
            get { return selectedmovie; }
            set 
            { 
                selectedmovie = value;
                OnPropertyChanged();
            }
        }


        private string searchterm ;

        public string SearchTerm
        {
            get { return searchterm; }
            set 
            { 
                searchterm = value;
                OnPropertyChanged();
            
            }
        }





        private string selected;
        public string SelectedMovieId
        {
            get { return selected; }
            set { SetProperty(ref selected, value); }
        }



        public ICommand PerformSearchCommand { get; set; }

        public ICommand MovieChangedCommand { get; set; }

        private readonly INavigationService navigationService;


        public MainViewViewModel(INetworkService _networkService,INavigationService navigation)
        {
            networkService = _networkService;

            navigationService = navigation;

            OnPropertyChanged("Items");

            

            PerformSearchCommand = new Command(async () => await GetMovieData());

            MovieChangedCommand = new Command(async () => { await GoToMovieDetails(); });
        }

        private async Task GoToMovieDetails()
        {

            if (SelectedMovie == null)
                return;


            SelectedMovieId = SelectedMovie.imdbID;
            await navigationService.PushAsync<MovieDetailsViewModel>(SelectedMovie);
            SelectedMovie = null;

        }

        private async Task GetMovieData()
        {




            var result = await networkService.GetAsync<ListOfMovies>(WebRelated.GetMoviesUri(SearchTerm));

            
            if(result.Response != "False")
            {
                Items = new ObservableCollection<MovieData>(result.Search
               .Select(x => new MovieData(x.Title, x.Poster.Replace("SX300", "SX600"), x.Year, x.imdbID)));
                OnPropertyChanged("Items");
            }else
            {
               await Application.Current.MainPage.DisplayAlert("Message", $"Search Movie {SearchTerm} not available ", "OK");
            }

           


        }
    }
}
