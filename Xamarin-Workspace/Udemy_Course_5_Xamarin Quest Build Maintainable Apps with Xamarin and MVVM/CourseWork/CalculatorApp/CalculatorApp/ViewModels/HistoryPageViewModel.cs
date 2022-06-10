using CalculatorApp.DependencyClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculatorApp.ViewModels
{
   public class HistoryPageViewModel : BaseViewModel
    {

       
        public ObservableCollection<string> Items { get; set; } 
         
        public ICommand DeleteCommand { get; set; }
        public HistoryPageViewModel()
        {
            DeleteCommand = new Command<string>(DeleteItem);
            
        }

        private void DeleteItem(string item)
        {
            Items.Remove(item);

            MessagingCenter.Send(this, "Items", new List<string>(Items));

            
        }

        public override Task InitializeAsync(object parameter)
        {
            Items = new ObservableCollection<string>(parameter as List<string>);
            OnPropertyChanged("Items");
          
            return Task.CompletedTask;
        }
    }
}
