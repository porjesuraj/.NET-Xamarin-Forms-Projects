using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace XamlNavigation.Models
{
  
  public  class Post
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Address { get; set; }

        public double  Latitude { get; set; }
        public double Longitude { get; set; }

        public int Distance { get; set; }


        public int UserId { get; set; }

        public static async Task<int> Insert(Post post)
        {
          return  await App.connect.InsertAsync(post);
        }

        public static async Task<ObservableCollection<Post>> LoadPost()
        {
           

            var posts = await  App.connect.Table<Post>().ToListAsync();

            return new ObservableCollection<Post>(posts);
        }
        public static async Task<ObservableCollection<Post>> LoadUserPost()
        {


          
            var posts = await App.connect.Table<Post>().Where(p => p.UserId == App.users.Id).ToListAsync();

            return new ObservableCollection<Post>(posts);
        }

        public static async Task<int> DeleteUserPost( Post p)
        {
            
            return await App.connect.DeleteAsync(p);
        }

        public static async Task<int> UpdateUserPost(Post p)
        {

            return await App.connect.UpdateAsync(p);
        }

        public static Dictionary<string, int> PostCategories(ObservableCollection<Post> postTable)
        {
            var categories = (from p in postTable
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();


            var categories2 = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();


            foreach (var category in categories)
            {
                var count = (from post in postTable
                             where post.CategoryName == category
                             select post).ToList().Count();

                var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count();


                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }
    }
}
