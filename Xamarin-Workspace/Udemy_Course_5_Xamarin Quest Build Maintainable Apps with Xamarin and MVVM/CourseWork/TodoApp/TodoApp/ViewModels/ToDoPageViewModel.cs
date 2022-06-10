using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TodoApp.Models;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
   public class ToDoPageViewModel : BindableObject
    {
        public ObservableCollection<ToDoItem> ToDoItemCollection { get; set; }

        public event EventHandler<double> UpdateProgressBar;


        public string PageTitle { get; set; }

        private ToDoItem selectedItem;
        public ToDoItem SelectedItem    
        {
            get { return selectedItem; }
            set { selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            }
        }


        public ICommand AddItemCommand => new Command(() => AddNewItem());

        public ICommand MarkAsCompletedCommand { get; set; }


        private string completedHeader;

        public string CompletedHeader
        {
            get { return completedHeader; }
            set 
            { 
                completedHeader = value;
                OnPropertyChanged();

            }
        }

        private double completedProgress;

        public double CompletedProgress
        {
            get { return completedProgress; }
            set 
            {
                completedProgress = value;
                OnPropertyChanged();
            
            }
        }




        public ToDoPageViewModel()
        {
            ToDoItemCollection = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());

            MarkAsCompletedCommand = new Command<ToDoItem>(c => MarkAsCompleted(c));

            CalculateCompletedHeader();

        }


        private void AddNewItem()
        {
            ToDoItemCollection.Add(new ToDoItem($"ToDo Item {ToDoItemCollection.Count + 1}"));

            CalculateCompletedHeader();
        }

        private void MarkAsCompleted(ToDoItem c)
        {
            c.IsCompleted = true;

            ToDoItemCollection.Remove(c);

            ToDoItemCollection.Add(c);


            CalculateCompletedHeader();
        }

        private void CalculateCompletedHeader()
        {
            CompletedHeader = $"Completed {ToDoItemCollection.Count(item => item.IsCompleted)} / {ToDoItemCollection.Count}";

            CompletedProgress = (double) ToDoItemCollection.Count(item => item.IsCompleted) / (double)ToDoItemCollection.Count;


            UpdateProgressBar?.Invoke(this, CompletedProgress);
        }
    }
}
