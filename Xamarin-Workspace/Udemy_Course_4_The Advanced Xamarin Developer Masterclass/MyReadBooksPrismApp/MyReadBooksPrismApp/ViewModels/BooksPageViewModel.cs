using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using Prism.Commands;
using System.Windows.Input;
using MyReadBooksPrismApp.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using SQLite;
using Prism.AppModel;
using Xamarin.Forms;

namespace MyReadBooksPrismApp.ViewModels
{
    class BooksPageViewModel : IPageLifecycleAware
    {

        INavigationService navigateService;

        public ICommand NewBookCommand { get; set; }

        public ICommand ListItemSelectedCommand { get; set; }

        public ObservableCollection<Item> SavedBooks { get; set; } = new ObservableCollection<Item>();

        public BooksPageViewModel(INavigationService navigationService)
        {
            navigateService = navigationService;

            NewBookCommand = new DelegateCommand(NewBookAction);

            ListItemSelectedCommand = new DelegateCommand<object>(GoToDetails,CanGoToDetails);


        }

        private bool CanGoToDetails(object arg)
        {
            return arg != null;
            
        }

        private async void GoToDetails(object obj)
        {
            var selectedBook = (obj as ListView).SelectedItem as Item;

            var parameter = new NavigationParameters();

            parameter.Add("selected_book", selectedBook);

            await navigateService.NavigateAsync("BookDetailsPage", parameter);
            
        }

        private void ReadSavedBook()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.Databasepath))
                {
                    conn.CreateTable<Item>();

                    var books = conn.Table<Item>().ToList();

                    foreach (var b in books)
                    {
                        SavedBooks.Add(b);

                    }

                }
            }
            catch (Exception ex)
            {

                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
          
        }

        private void NewBookAction()
        {
            navigateService.NavigateAsync("NewBookPage");
        }

        public void OnAppearing()
        {
            ReadSavedBook();
        }

        public void OnDisappearing()
        {
            SavedBooks.Clear();
        }
    }
}
