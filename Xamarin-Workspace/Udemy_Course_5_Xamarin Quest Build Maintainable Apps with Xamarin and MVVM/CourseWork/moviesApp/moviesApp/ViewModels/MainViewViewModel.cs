using moviesApp.Constants;
using moviesApp.Models;
using moviesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace moviesApp.ViewModels
{
    public class MainViewViewModel : BindableObject
    {
        private INetworkService networkService;

        public ObservableCollection<MovieData> Items { get; set; }


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


        public ICommand PerformSearchCommand { get; set; }


        public MainViewViewModel(INetworkService _networkService)
        {
            networkService = _networkService;

            OnPropertyChanged("Items");

            

            PerformSearchCommand = new Command(async () => await GetMovieData());
        }

       

        

        private async Task GetMovieData()
        {
            var result = await networkService.GetAsync<ListOfMovies>(WebRelated.GetMoviesUri(SearchTerm));


            Items = new ObservableCollection<MovieData>(result.Search
                .Select(x => new MovieData(x.Title,x.Poster.Replace("SX300","SX600"))));
            OnPropertyChanged("Items");


        }
    }
}
