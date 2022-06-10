using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using PrismDemo1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;

namespace PrismDemo1.ViewModels
{
    public class RestPage1ViewModel : BindableBase
    {

        public ObservableCollection<Post> Posts { get; private set; } = new ObservableCollection<Post>();

        public IPostService _postService;


        public RestPage1ViewModel()
        {

        

           Posts = new ObservableCollection<Post>
            {
               
                new Post{id = 1, body="one ", title="1one"},
                new Post{id = 1, body="one ", title="1one"},
                new Post{id = 1, body="one ", title="1one"},
                new Post{id = 1, body="one ", title="1one"}
            };



        }



       
    }
}
