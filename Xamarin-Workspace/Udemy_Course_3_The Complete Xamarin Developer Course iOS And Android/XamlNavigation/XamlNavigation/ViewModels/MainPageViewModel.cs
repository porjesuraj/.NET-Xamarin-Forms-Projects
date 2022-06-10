using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamlNavigation.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        INavigationService _navigationService;


        public DelegateCommand ToLoginPageCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            _navigationService = navigationService;

            ToLoginPageCommand = new DelegateCommand(ExecuteToLoginPage);
        }

        private void ExecuteToLoginPage()
        {
            _navigationService.NavigateAsync("LoginPage");
        }
    }
}
