using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamlNavigation.ViewModels
{
    public class HomePageViewModel : ViewModelBase 
    {

        private string _email;
        public string email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public DelegateCommand AddCommand { get; }

        private IPageDialogService _pageDialogService;

        private INavigationService _navigationService;
        public HomePageViewModel(IPageDialogService pageDialogService, INavigationService navigationService):base(navigationService)
        {
            _pageDialogService = pageDialogService;

            _navigationService = navigationService;

            AddCommand = new DelegateCommand(ExecuteAddCommand);
        }

        private  void ExecuteAddCommand()
        {
            _navigationService.NavigateAsync("NewTravelPage");
            
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var e= parameters.GetValue<string>("email");

            email = $"Welcome {e}";

            _pageDialogService.DisplayAlertAsync("Greetings", $"Welcome {e}", "OK");
        }
    }
}
