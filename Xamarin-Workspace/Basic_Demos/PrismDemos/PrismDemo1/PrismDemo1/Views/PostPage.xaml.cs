using Newtonsoft.Json;
using PrismDemo1.Models;
using PrismDemo1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;

namespace PrismDemo1.Views
{
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            (BindingContext as PostPageViewModel).LoadPostCommand.Execute();
            base.OnAppearing();
        }


        /*   private const string Url = "https://jsonplaceholder.typicode.com/posts";

           private HttpClient _client = new HttpClient();

           private ObservableCollection<Post> _posts;




           protected async override void OnAppearing()
           {

               var content = await _client.GetStringAsync(Url);

               var posts = JsonConvert.DeserializeObject<List<Post>>(content);


               _posts = new ObservableCollection<Post>(posts);

               postView.ItemsSource = _posts;
               base.OnAppearing();


           }

           private async void OnAdd(object sender, EventArgs e)
           {
               var post = new Post { Title = "Title" + DateTime.Now.Ticks };
               _posts.Insert(0, post);

               var content = JsonConvert.SerializeObject(post);

               await _client.PostAsync(Url, new StringContent(content));



           }

           private async void OnUpdate(object sender, EventArgs e)
           {
               var post = _posts[0];

               post.Title += "UPDATED";

               var content = JsonConvert.SerializeObject(post);

               await _client.PutAsync(Url + "/" + post.Id, new StringContent(content));

           }

           private void OnDelete(object sender, EventArgs e)
           {
               var post = _posts[0];
               _posts.Remove(post);
               _client.DeleteAsync(Url + "/" + post.Id);



           }*/
    }
}
