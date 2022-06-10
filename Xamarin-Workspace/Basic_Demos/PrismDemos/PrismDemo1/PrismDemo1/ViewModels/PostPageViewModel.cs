using Prism.Commands;
using Prism.Mvvm;
using PrismDemo1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace PrismDemo1.ViewModels
{
    public class PostPageViewModel : BindableBase
    {

        private ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();

        private string BaseUrl = "https://jsonplaceholder.typicode.com/posts";

        private HttpClient client = new HttpClient();

        private string Poster; 
        public DelegateCommand LoadPostCommand; 

       async void ExecuteLoadPostCommand()
        {
            var content = await client.GetStringAsync(BaseUrl);

            var posts = JsonConvert.DeserializeObject<List<Post>>(content);

            Poster = posts[0].ToString();

          /*  foreach (var p in posts)
                Posts.Add(p);*/

         Posts = new ObservableCollection<Post>(posts);

        }


        private PostService _service; 

        public PostPageViewModel()
        {

            LoadPostCommand = new DelegateCommand(ExecuteLoadPostCommand);

            

          

        }
    }
}
