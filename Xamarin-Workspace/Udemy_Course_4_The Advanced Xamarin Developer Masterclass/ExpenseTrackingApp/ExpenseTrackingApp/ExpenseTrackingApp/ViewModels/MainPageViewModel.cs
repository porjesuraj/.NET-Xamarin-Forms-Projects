using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTrackingApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public INavigationService navigationService1;
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            navigationService1 = navigationService;
        }
    }
}
