using moviesApp.Common.Base;
using moviesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using moviesApp.Common.Navigation;
using moviesApp.Services;
using System.Windows.Input;
using Xamarin.Forms;
using moviesApp.Common.Databases;
using System.Linq;

namespace moviesApp.Modules.MovieDetails
{
   public class MovieDetailsViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;

        private INetworkService networkService;

        private IRepository<FullMovieInformation> movieInfoRepository;

        private MovieData movieData;

        public ICommand GoBackCommand { get; set; }

        public ICommand FavoriteCommand { get; set; }

        public MovieDetailsViewModel(INavigationService navigationService, INetworkService networkService, IRepository<FullMovieInformation> repository)
        {
            this.navigationService = navigationService;
            this.networkService = networkService;

            movieInfoRepository = repository;

            GoBackCommand = new Command(async () => await GoBack());

            FavoriteCommand = new Command(async () => await SetMovieAsFavorite());
        }

        private async Task SetMovieAsFavorite()
        {
            IsFavorite = !IsFavorite;


            MovieInformation.IsFavorite = IsFavorite;
           await movieInfoRepository.SaveAsync(movieInformation);
        }

        private async Task GoBack()
        {
          await  navigationService.PopAsync();
        }

        public MovieData MoviesData
        {
            get { return movieData; }
            set
            { 
                movieData = value;
                OnPropertyChanged();
            }
        }


        private FullMovieInformation movieInformation;

        public FullMovieInformation MovieInformation
        {
            get { return movieInformation; }
            set
            { 
                movieInformation = value;
                OnPropertyChanged();
            }
        }



        private bool isfavorite;

        public bool IsFavorite
        {
            get { return isfavorite; }
            set
            {
                isfavorite = value;
                OnPropertyChanged();
            }
        }




        public override async Task InitializeAsync(object parameter)
        {
            MoviesData = (MovieData)parameter; 

           MovieInformation =  await networkService.GetAsync<FullMovieInformation>(Constants.WebRelated.GetMovieById(MoviesData.imdbID));


            var dbinfo = (await movieInfoRepository.GetAllAsync()).FirstOrDefault( x => x.imdbID == MovieInformation.imdbID);

            if (dbinfo != null)
            {
                MovieInformation.Id = dbinfo.Id;

                IsFavorite = dbinfo.IsFavorite;

            }

            

        }
    }
}
