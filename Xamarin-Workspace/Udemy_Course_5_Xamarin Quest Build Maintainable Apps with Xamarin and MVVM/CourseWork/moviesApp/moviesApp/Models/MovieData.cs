using System;
using System.Collections.Generic;
using System.Text;

namespace moviesApp.Models
{
  public  class MovieData
    {
        public MovieData(string title, string imageUrl,string year,string imdbId)
        {
            Title = title;
            ImageUrl = imageUrl;
            Year = year;
            imdbID = imdbId;
        }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Year { get; set; }
        public string imdbID { get; set; }

    }
}
