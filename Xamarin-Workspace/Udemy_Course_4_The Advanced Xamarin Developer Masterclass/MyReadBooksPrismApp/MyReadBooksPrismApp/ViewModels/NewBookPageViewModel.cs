using MyReadBooksPrismApp.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Input;
using Prism.Commands;
using MyReadBooksPrismApp.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace MyReadBooksPrismApp.ViewModels
{





   

    class NewBookPageViewModel
    {
        public ObservableCollection<Item> SearchResults { get; set; } = new ObservableCollection<Item>(); 

        public ICommand SearchCommand { get; set; }
        public ICommand SaveCommand { get; set; }



        public NewBookPageViewModel()
        {
            SearchCommand = new DelegateCommand<string>(GetSearchResults);

            SaveCommand = new DelegateCommand<Item>(SaveBook,CanSaveBook);
        }

        private bool CanSaveBook(Item book)
        {
            return book != null;
        }

        private void SaveBook(Item book)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.Databasepath))
            {
                conn.CreateTable<Item>();
                int bookInserted = conn.Insert(book);

                if(bookInserted >= 1)
                {
                    App.Current.MainPage.DisplayAlert("Success", "Book saved", "OK");
                }else
                {
                    App.Current.MainPage.DisplayAlert("Failed", "An error occured while saving the book", "OK");

                }
            }
        }


        private async void GetSearchResults(string query)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={query}:keyes&key={Constants.GOOGLE_BOOKS_API_KEY}");

                    var data = JsonConvert.DeserializeObject<Models.BooksApi>(result);

                    SearchResults.Clear();

                    foreach (var book in data.items)
                    {
                        SearchResults.Add(book);
                    }
                }

            }
            catch (Exception ex)
            {

               await   App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }


        }
    }

   

}
