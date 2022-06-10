using System;
using System.Collections.Generic;
using System.Text;

namespace moviesApp.Constants
{
   public static class WebRelated
    {
        public static string GetMoviesUri(string searchTerm)
        {
            return $"https://www.omdbapi.com/?apikey=5d361716&s={searchTerm}&page=1";
        }

        public static string GetMovieById(string imdbId)
        {
            return $"https://www.omdbapi.com/?apikey=5d361716&i={imdbId}&plot=full";
        }


    }
}
