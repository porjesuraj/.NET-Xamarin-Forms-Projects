using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using MyReadBooksPrismApp.Models;
using Prism.Commands;
using Prism.Navigation;
using SQLite;
namespace MyReadBooksPrismApp.ViewModels
{
    class BookDetailsPageViewModel : INavigatedAware, INotifyPropertyChanged
    {
        private string bookName;
        public string BookName
        {
            get { return bookName; }
            set 
            {
                bookName = value;
                OnPropertyChanged("BookName");
            }
        }

        private string bookAuthor;

        public string BookAuthor
        {
            get { return bookAuthor; }
            set 
            { 
                bookAuthor = value;
                OnPropertyChanged("BookAuthor");
            }
        }


        private string bookImageUrl;

        public string BookImageUrl
        {
            get { return bookImageUrl; }
            set 
            { 
                bookImageUrl = value;

                OnPropertyChanged("BookImageUrl");
            }
        }



        public ICommand DeleteBookCommand { get; set; }


        public Item SelectedBook;

        public event PropertyChangedEventHandler PropertyChanged;


        public BookDetailsPageViewModel()
        {
            DeleteBookCommand = new DelegateCommand(DeleteBookAction);
        }

        private void DeleteBookAction()
        {
            string title = SelectedBook.title;
            using(SQLiteConnection connection = new SQLiteConnection(App.Databasepath))
            {
                connection.CreateTable<Item>();
                int booksDeleted = connection.Delete(SelectedBook);

                if(booksDeleted >= 1)
                {
                    App.Current.MainPage.DisplayAlert("Success", $" {title} Book Successfully Deleted", "Ok");


                }else
                {
                    App.Current.MainPage.DisplayAlert("Failed", $" An error occured while deleeting  {title} Book", "Ok");

                }
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            SelectedBook = parameters["selected_book"] as Item;

            BookName = SelectedBook.title;

            BookAuthor = SelectedBook.authors;

            BookImageUrl = SelectedBook.thumbnail;
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
