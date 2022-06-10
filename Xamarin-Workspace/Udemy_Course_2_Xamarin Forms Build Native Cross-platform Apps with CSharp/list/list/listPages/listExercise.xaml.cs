using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using list.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace list.listPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listExercise : ContentPage
    {

        private ObservableCollection<Search> searchProperty;
        private ObservableCollection<SearchGroup> searchGroupProperty;

        IEnumerable<Search> GetSearchBar(string searchLocal = null)
        {
            var searches = new ObservableCollection<Search>
            {

                   new Search { Id = 1, CheckIn = new DateTime(2018,01,01), CheckOut = new DateTime(2020,01,01), Location = "NewYork,USA",ImageUrl="https://picsum.photos/200/300?random=1" },
                    new Search { Id = 2, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2021,01,01), Location = "New Jersey,USA", ImageUrl="https://picsum.photos/200/300?random=2" },
                    new Search { Id = 3, CheckIn = new DateTime(2020,01,01), CheckOut = new DateTime(2022,01,01), Location = "Califonia,USA", ImageUrl="https://picsum.photos/200/300?random=3" },
                    new Search { Id = 4, CheckIn =new DateTime(2021,01,01), CheckOut = new DateTime(2023,01,01), Location = "Texas ,USA", ImageUrl="https://picsum.photos/200/300?random=4" },

                       new Search { Id = 5, CheckIn = new DateTime(2019,01,01), CheckOut = new DateTime(2020,01,01), Location = "NewYork,USA",ImageUrl="https://picsum.photos/200/300?random=5" },
                    new Search { Id = 6, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2021,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=6" },
                    new Search { Id = 7, CheckIn = new DateTime(2019,01,01), CheckOut = new DateTime(2022,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=7" },
                    new Search { Id = 8, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2023,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=8" }


            };

            if (String.IsNullOrWhiteSpace(searchLocal))
                return searches;
            else
                return searches.Where(s =>  s.Location.StartsWith(searchLocal));


        }


        ObservableCollection<SearchGroup> GetSearchGroups()
        {

           


            return new ObservableCollection<SearchGroup>
            {
                new SearchGroup("Recent Searches",new List<Search> 
                {

                       new Search { Id = 1, CheckIn = new DateTime(2018,01,01), CheckOut = new DateTime(2020,01,01), Location = "NewYork,USA",ImageUrl="https://picsum.photos/200/300?random=1" },
                    new Search { Id = 2, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2021,01,01), Location = "New Jersey,USA", ImageUrl="https://picsum.photos/200/300?random=2" },
                    new Search { Id = 3, CheckIn = new DateTime(2020,01,01), CheckOut = new DateTime(2022,01,01), Location = "Califonia,USA", ImageUrl="https://picsum.photos/200/300?random=3" },
                    new Search { Id = 4, CheckIn =new DateTime(2021,01,01), CheckOut = new DateTime(2023,01,01), Location = "Texas ,USA", ImageUrl="https://picsum.photos/200/300?random=4" },


                }),
                new SearchGroup("All",new List<Search>
                {

                       new Search { Id = 1, CheckIn = new DateTime(2018,01,01), CheckOut = new DateTime(2020,01,01), Location = "NewYork,USA",ImageUrl="https://picsum.photos/200/300?random=1" },
                    new Search { Id = 2, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2021,01,01), Location = "New Jersey,USA", ImageUrl="https://picsum.photos/200/300?random=2" },
                    new Search { Id = 3, CheckIn = new DateTime(2020,01,01), CheckOut = new DateTime(2022,01,01), Location = "Califonia,USA", ImageUrl="https://picsum.photos/200/300?random=3" },
                    new Search { Id = 4, CheckIn =new DateTime(2021,01,01), CheckOut = new DateTime(2023,01,01), Location = "Texas ,USA", ImageUrl="https://picsum.photos/200/300?random=4" },

                       new Search { Id = 5, CheckIn = new DateTime(2019,01,01), CheckOut = new DateTime(2020,01,01), Location = "NewYork,USA",ImageUrl="https://picsum.photos/200/300?random=5" },
                    new Search { Id = 6, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2021,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=6" },
                    new Search { Id = 7, CheckIn = new DateTime(2019,01,01), CheckOut = new DateTime(2022,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=7" },
                    new Search { Id = 8, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2023,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=8" }


                })
            };

              
          }

        ObservableCollection<Search> GetSearchCollection()
        {
           var searchesCollection =  new ObservableCollection<Search>
            {
                     new Search { Id = 1, CheckIn = new DateTime(2018,01,01), CheckOut = new DateTime(2020,01,01), Location = "NewYork,USA",ImageUrl="https://picsum.photos/200/300?random=1" },
                    new Search { Id = 2, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2021,01,01), Location = "New Jersey,USA", ImageUrl="https://picsum.photos/200/300?random=2" },
                    new Search { Id = 3, CheckIn = new DateTime(2020,01,01), CheckOut = new DateTime(2022,01,01), Location = "Califonia,USA", ImageUrl="https://picsum.photos/200/300?random=3" },
                    new Search { Id = 4, CheckIn =new DateTime(2021,01,01), CheckOut = new DateTime(2023,01,01), Location = "Texas ,USA", ImageUrl="https://picsum.photos/200/300?random=4" },

                       new Search { Id = 5, CheckIn = new DateTime(2019,01,01), CheckOut = new DateTime(2020,01,01), Location = "NewYork,USA",ImageUrl="https://picsum.photos/200/300?random=5" },
                    new Search { Id = 6, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2021,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=6" },
                    new Search { Id = 7, CheckIn = new DateTime(2019,01,01), CheckOut = new DateTime(2022,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=7" },
                    new Search { Id = 8, CheckIn =new DateTime(2019,01,01), CheckOut = new DateTime(2023,01,01), Location = "NewYork,USA", ImageUrl="https://picsum.photos/200/300?random=8" }


            };

            return searchesCollection; 
        }



        public listExercise()
        {
            InitializeComponent();

          /*  searchGroupProperty = GetSearchGroups();
            lists.ItemsSource = searchGroupProperty;*/
            
          searchProperty = GetSearchCollection();
         lists.ItemsSource = searchProperty;  

          

        }

        

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lists.ItemsSource = GetSearchBar(e.NewTextValue); 
        }

        private void MenuItem_Called(object sender, EventArgs e)
        {
            var searches = (sender as MenuItem).CommandParameter as Search;

            DisplayAlert("Location", searches.Location, "OK"); 

        }

        private void MenuItem_Deleted(object sender, EventArgs e)
        {
            var searches = (sender as MenuItem).CommandParameter as Search;

            
            searchProperty.Remove(searches);
        
        }

        private void lists_Refreshing(object sender, EventArgs e)
        {
            lists.ItemsSource = searchProperty;
            lists.EndRefresh(); 
        }
    }
}