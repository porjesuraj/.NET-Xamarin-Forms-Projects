using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using XamlNavigation.Models;
using XamlNavigation.Services;

namespace XamlNavigation.ViewModels
{
    public class ProfilePageViewModel : BindableBase, IPageLifecycleAware
    {

        private Dictionary<string, int> postListSource;
        public Dictionary<string, int> PostListSource
        {
            get { return postListSource; }
            set { SetProperty(ref postListSource, value); }
        }

        private string postCount;
        public string PostCountLabel
        {
            get { return postCount; }
            set { SetProperty(ref postCount, value); }
        }



        public ISQLService _sqlService { get; private set; }

        public ProfilePageViewModel(ISQLService sQLService )
        {
            _sqlService = sQLService;
        }

        public async void OnAppearing()
        {
           // SQLiteAsyncConnection conn = App.connect;

           // await conn.CreateTableAsync<Post>();

           // var postTable = await conn.Table<Post>().ToListAsync();
            var postTable = await Post.LoadUserPost();

            PostCountLabel = postTable.Count.ToString();

           /* var categories = (from p in postTable
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();


            var categories2 = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>(); 


            foreach(var category in categories)
            {
                var count = (from post in postTable
                             where post.CategoryName == category
                             select post).ToList().Count();

                var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count();


                categoriesCount.Add(category, count); 
            }*/

            PostListSource = Post.PostCategories(postTable); 



         //await  conn.CloseAsync();

        }

        public void OnDisappearing()
        {
            
            
        }
    }
}
