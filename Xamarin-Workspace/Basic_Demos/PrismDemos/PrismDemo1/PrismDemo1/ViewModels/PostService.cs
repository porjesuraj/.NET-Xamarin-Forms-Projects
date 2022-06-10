using Newtonsoft.Json;
using PrismDemo1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo1.ViewModels
{
    public class PostService : IPostService
    {
       private readonly string BaseUrl = "https://jsonplaceholder.typicode.com/posts";

       private readonly HttpClient client = new HttpClient();


      

       async Task<ObservableCollection<Post>> IPostService.getPosts()
        {
            var content = await client.GetStringAsync(BaseUrl);

            var posts = JsonConvert.DeserializeObject<List<Post>>(content);

            return new ObservableCollection<Post>(posts);
        }
    }
}
