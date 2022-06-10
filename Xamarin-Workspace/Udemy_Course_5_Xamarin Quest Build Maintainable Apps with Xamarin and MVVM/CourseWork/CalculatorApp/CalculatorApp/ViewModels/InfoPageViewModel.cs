using CalculatorApp.DependencyClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.ViewModels
{
   public class InfoPageViewModel : BaseViewModel
    {
        public InfoPageViewModel(HistoryPageViewModel historyVM)
        {
            HistoryVM = historyVM;
        }

        public HistoryPageViewModel HistoryVM { get; set; }

        public override Task InitializeAsync(object parameter)
        {
            return HistoryVM.InitializeAsync(parameter);
        }
    }
}
